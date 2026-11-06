# ECommerce — MVP Geliştirme Planı (Revizyon 2)

> Güncelleme: 2026-11-06 · Durum: Onay bekliyor (açık kararlar en altta)

## MVP tanımı

**Tek satıcılı** bir e-ticaret back-end'i:

1. **Yerel e-ticaret sitesi** için ürün, müşteri ve sipariş yönetimi.
2. **Pazaryeri modülü** (MVP'de yalnızca Trendyol): ürünlerin Trendyol'a gönderilmesi, fiyat/stok senkronu, Trendyol siparişlerinin işlenmesi.
3. İkisinin entegrasyonu: tek ürün kataloğu, tek stok, tüm kanalların siparişleri tek yerde.

**Mimari kararlar**
- Back-end ve front-end ayrı projeler. Back-end bir **ASP.NET Core Web API**; front-end (React veya Vue) **en son** yapılır.
- SaaS değil. Tek satıcı olduğu için kiracı (tenant) modeli yok; Trendyol bilgileri konfigürasyonda/secret'ta tutulur.
- Back-end operasyonları **TDD** ile geliştirilir (bkz. "TDD yaklaşımı").
- Yayın **Docker** ile yapılır.

**Kapsam dışı (MVP sonrası):** N11, Hepsiburada, kupon/indirim, XML scheduler, soru-cevap, iade/claim, Redis, çoklu dil.

---

## Hedef çözüm yapısı

```
src/
  ECommerce.API              ← YENİ: Web API (controller'lar, auth, OpenAPI)
  ECommerce.Application      ← servisler, use-case'ler, validasyon
  ECommerce.Domain           ← entity'ler, domain kuralları
  ECommerce.Persistence      ← EF Core (ECommerce.EntityFramework yeniden adlandırılır)
  ECommerce.Core             ← ortak altyapı (Result, extension'lar)
marketplaces/
  Trendyol.Client            ← Trendyol HTTP client'ı
tests/
  ECommerce.UnitTests
  ECommerce.IntegrationTests ← WebApplicationFactory + Testcontainers
  Trendyol.Client.Tests      ← WireMock ile sözleşme testleri
frontend/                    ← Faz 6
docker/                      ← Faz 5
```

- `ECommerce.CustomerPortal` (MVC) dondurulur, Faz 3 sonunda silinir (git geçmişinde kalır).
- `N11.Client` ve `Hepsiburada.Client` Application'dan bağlantısı kesilip solution'dan çıkarılır; MVP sonrası geri alınır.
- `ECommerce.ImageAPI` ayrı servis olarak kalmaz; görsel yükleme API'nin bir modülü olur (bkz. Açık kararlar #3).

---

## Trendyol dokümantasyonu ile mevcut client arasındaki farklar

[Trendyol geliştirici dokümanı](https://developers.trendyol.com/docs/getting-started) incelendiğinde mevcut `Trendyol.Client`'ın büyük kısmı güncel değil:

| Konu | Mevcut kod | Güncel doküman |
|---|---|---|
| Base URL | `https://api.trendyol.com` + `/sapigw/...` | Prod `https://apigw.trendyol.com`, Stage `https://stageapigw.trendyol.com` |
| Ürün yaratma | `/sapigw/suppliers/{id}/v2/products` | `/integration/product/sellers/{sellerId}/v2/products` |
| Sipariş paketleri | `/sapigw/suppliers/{id}/orders` (v1) | `/integration/order/sellers/{sellerId}/v2/orders` — **v1 15.10.2026'da kapatıldı**, mevcut sipariş listeleme büyük ihtimalle çalışmıyor |
| Rate limit | Ele alınmıyor | 14.09.2026'dan itibaren servis **grubu** bazlı dakikalık limit; 429 cevabı |
| Stage ortamı | Yok | Çıkış IP'si Trendyol'a whitelist ettirilmeli (aksi halde 503) |
| User-Agent | `{SellerId} - SelfIntegration` ✔ | Aynı; eksikse 403 |
| `TrendyolDiscoveryClient` | Trendyol web sitesini tarıyor | Resmi API değil — kaldırılacak |

Bu yüzden Faz 3'ün ilk işi client'ı güncel uçlara taşımak.

---

## TDD yaklaşımı

- **Kural:** Faz 2'den itibaren her yeni davranış önce başarısız bir testle başlar (Red → Green → Refactor). Faz 1'deki refaktörlerde önce mevcut davranışı sabitleyen *karakterizasyon testi* yazılır.
- **Test piramidi**
  - *Unit:* domain kuralları, Application servisleri (bağımlılıklar mock'lanır).
  - *Sözleşme:* Trendyol client'ı ↔ WireMock.Net; istek/yanıt örnekleri Trendyol dokümanındaki örneklerden alınır.
  - *Entegrasyon:* `WebApplicationFactory` + Testcontainers (MSSQL) ile API uçları gerçek veritabanına karşı.
  - *Canlı (manuel/opsiyonel):* Trendyol stage ortamına karşı, `[Trait("Category","Live")]`, CI'da çalışmaz.
- **Araçlar:** xUnit, NSubstitute, Shouldly, WireMock.Net, Testcontainers.MsSql, coverlet.
- **Bitti tanımı (her iş için):** testler yeşil, CI yeşil, OpenAPI dokümanı güncel, gizli bilgi yok.

---

## Faz 0 — Acil: Güvenlik, derleme, platform (1 gün)

- [ ] **Anahtarları iptal et ve yenile** *(satıcı tarafından yapılacak)*: Trendyol (git geçmişinde açık), N11, SQL Server (`talipbulundu.com`) şifresi. Hepsi git geçmişinde kalıcı olarak duruyor.
- [x] Bozuk maskeleme düzeltildi; Trendyol bilgileri `IOptions<TrendyolOptions>` ile `Trendyol` konfigürasyon bölümünden okunuyor. Eksikse uygulama açılışta anlaşılır bir hatayla duruyor (`ValidateOnStart`).
- [x] Repodaki düz metin gizli bilgiler kaldırıldı (`queries.txt`, N11 testi → ortam değişkeni + `TestCategory("Live")`); `.gitignore`'a `.env`, `*.local.json`, `secrets.json` eklendi.
- [x] **.NET 10'a geçildi:** tüm projeler `net10.0`, EF Core / Extensions / RuntimeCompilation 10.0.14, `Microsoft.Data.SqlClient` 6.1.8, `global.json` (SDK 10.0.403, `latestFeature`).
- [x] Geçişli `System.Security.Cryptography.Pkcs` güvenlik açıkları sabitlenerek kapatıldı. Kalanlar Faz 1'de: AutoMapper (→ Mapster), Swashbuckle 6.2.3 (ImageAPI birleşirken).
- [x] GitHub Actions: `.github/workflows/ci.yml` (restore, build, `TestCategory!=Live` testleri). Solution'daki büyük/küçük harf yol hatası Linux için düzeltildi.

**Kabul:** `dotnet build` hatasız ✔, repoda gizli bilgi yok ✔, hedef framework `net10.0` ✔, CI yeşil ⏳ (ilk push'ta doğrulanacak).

**Yerel çalıştırma:**
```bash
cd src/ECommerce.CustomerPortal
dotnet user-secrets set "Trendyol:SellerId" "<seller-id>"
dotnet user-secrets set "Trendyol:ApiKey" "<api-key>"
dotnet user-secrets set "Trendyol:ApiSecret" "<api-secret>"
```

---

## Faz 1 — Proje temeli ve altyapı (6–8 gün)

### 1.1 API projesi
- [ ] `ECommerce.API` oluştur: controller tabanlı Web API, OpenAPI + Scalar/Swagger UI, API versiyonlama (`/api/v1`).
- [ ] Standart cevap modeli: `IDataResult` / ProblemDetails; global exception handler.
- [ ] Komposizyon kökü API'de: `AddApplication()`, `AddPersistence()`, `AddTrendyol()` extension'ları. Autofac + Castle interceptor zinciri kaldırılır, yerleşik DI kullanılır.

### 1.2 Veri erişimi
- [ ] Bağlantı dizesini konfigürasyona taşı; `AddDbContext<ECommerceContext>`.
- [ ] `EfBaseEntityRepository` içindeki `new TContext()` kaldırılır; context DI'dan gelir, metotlar async olur.
- [ ] DB-first'ten code-first'e geç: mevcut şemadan baseline `InitialCreate` migration'ı.
- [ ] Entity konfigürasyonlarını `IEntityTypeConfiguration<T>` sınıflarına ayır.
- [ ] Ortak alanlar (`CreatedAt`, `UpdatedAt`, soft-delete) için interceptor.

### 1.3 Cross-cutting
- [ ] Loglama: `ILogger` + Serilog (konsol + dosya/Seq); `DbLogManager` ve `LogAspect` kaldırılır.
- [ ] Cache: `IMemoryCache` / `HybridCache` doğrudan servis içinde; `CacheAspect` kaldırılır.
- [ ] Validasyon: FluentValidation, endpoint filtresi ile; `ValidationAspect` kaldırılır.
- [ ] `SecurityOperationAspect` kaldırılır (Faz 2'de policy tabanlı yetkilendirme gelir).
- [ ] HTTP client'lar: `IHttpClientFactory` + `Microsoft.Extensions.Http.Resilience` (retry, timeout, 429 için bekleme).

### 1.4 Temizlik ve bağımlılıklar
- [ ] csproj'lardaki ölü `Compile Remove` blokları, `Model1.tt`, `EntityFramework 6.5.1`, `System.Data.SqlClient` kaldırılır.
- [ ] AutoMapper kaldırılır, profiller **Mapster** `TypeAdapterConfig`'e taşınır (NU1903 güvenlik açığı da böylece kapanır). Mevcut `AutoMapperUT` testi Mapster konfigürasyon doğrulama testine dönüşür.
- [ ] Nullable uyarıları temizlenir; `TreatWarningsAsErrors`.
- [ ] Boş `NotImplementedException` servisleri silinir; Faz 4'te TDD ile yeniden yazılır.

### 1.5 Test altyapısı ve geliştirme ortamı
- [ ] Yeni xUnit test projeleri (yapı yukarıda); eski MSTest projeleri xUnit'e taşınır, boş olanlar silinir.
- [ ] `docker-compose.dev.yml`: yerel geliştirme için SQL Server.
- [ ] İlk entegrasyon testi: `GET /health` → 200.

**Kabul:** API boş bir veritabanına migration ile kuruluyor ve ayağa kalkıyor; hiçbir sınıf `new DbContext` / `new HttpClient` yapmıyor; test altyapısı CI'da çalışıyor.

---

## Faz 2 — Giriş ve güvenlik (4–5 gün) · TDD

- [ ] **Yönetici girişi:** `DefAdmin` + `PasswordHasher<T>` (PBKDF2); mevcut `HashigHelper` kaldırılır.
- [ ] **JWT access token** (kısa ömürlü) + **refresh token** (veritabanında, rotasyonlu, httpOnly cookie ile SPA'ya).
- [ ] Uçlar: `POST /auth/login`, `/auth/refresh`, `/auth/logout`, `GET /auth/me`, şifre değiştirme.
- [ ] Roller: `Admin` (MVP'de tek rol yeterli; policy yapısı genişlemeye açık).
- [ ] Brute-force koruması: login için rate limiting + hesap kilitleme.
- [ ] İlk yönetici için seed / CLI komutu (şifre ortam değişkeninden).
- [ ] Güvenlik: CORS (sadece front-end origin'i), HTTPS/HSTS, güvenlik header'ları, gizli bilgiler sadece secret/ortam değişkeninde.
- [ ] Müşteri (site kullanıcısı) kimlik doğrulaması Faz 4.2'de aynı altyapıyla eklenir.

**Kabul:** Korunan uçlar token'sız 401 dönüyor; refresh rotasyonu ve kilitleme testlerle doğrulanmış.

---

## Faz 3 — Trendyol ürün ve sipariş, uçtan uca (8–11 gün) · TDD

### 3.1 Client modernizasyonu
- [ ] Base URL ve path'ler güncel uçlara taşınır (yukarıdaki tablo); Prod/Stage ortam seçimi konfigürasyondan.
- [ ] Typed `HttpClient`, Basic auth + User-Agent handler, 429/5xx için resilience.
- [ ] Her uç için WireMock sözleşme testi (dokümandaki örnek JSON'larla).
- [ ] `TrendyolDiscoveryClient` ve kullanılmayan modeller kaldırılır.
- [ ] Stage ortamı için çıkış IP'sinin Trendyol'a whitelist ettirilmesi (çağrı merkezi üzerinden — operasyonel iş).

### 3.2 Referans veriler
- [ ] Kategori ağacı, kategori özellikleri ve değerleri, marka arama — cache'li (servis limiti düşük: dakikada 50).

### 3.3 Ürün
- [ ] Ürün listeleme/filtreleme (barkod, onay durumu, sayfalama).
- [ ] Ürün yaratma (v2), onaylı/onaysız ürün güncelleme (v2), silme.
- [ ] Fiyat ve stok güncelleme (barkod başına dakikada 30 fiyat güncellemesi sınırına dikkat).
- [ ] **Batch takibi:** dönen `batchRequestId` veritabanına yazılır; arka plan görevi sonucu sorgular, hatalı kalemleri kaydeder.

### 3.4 Sipariş
- [ ] Sipariş paketlerini çekme (v2, sayfa başı max 200, max 2 haftalık aralık); periyodik çekme işi.
- [ ] Paket statüsü: Picking → Invoiced.
- [ ] Tedarik edememe bildirimi.
- [ ] Fatura linki gönderme/silme.
- [ ] (Opsiyonel) Webhook ile sipariş bildirimi — public URL gerektirdiği için Faz 5 sonrasında açılır; o zamana kadar polling.

### 3.5 API uçları
- [ ] `/api/v1/marketplaces/trendyol/...` altında ürün, referans veri, sipariş ve batch uçları; hepsi `Admin` yetkili.
- [ ] `ECommerce.CustomerPortal` silinir.

**Kabul:** Stage ortamında (veya prod test ürünüyle) ürün yaratma → batch sonucu → fiyat/stok güncelleme → sipariş çekme → Picking → Invoiced → fatura linki akışı API üzerinden baştan sona çalışıyor; sözleşme ve entegrasyon testleri yeşil.

---

## Faz 4 — Yerel e-ticaret + pazaryeri entegrasyonu (13–18 gün) · TDD

### 4.1 Katalog (yönetim + vitrin okuma)
- [ ] Kategori, marka, ürün, varyant/seçenek, fiyat, görsel, stok — yönetici CRUD uçları.
- [ ] Görsel yükleme (Trendyol herkese açık URL istediği için kalıcı ve erişilebilir depolama).
- [ ] Vitrin için herkese açık okuma uçları: listeleme, filtre, arama, ürün detayı.

### 4.2 Müşteri, sepet ve sipariş (yerel site)
- [ ] Müşteri kaydı/girişi (Faz 2 altyapısıyla), adres yönetimi; misafir siparişi (opsiyonel).
- [ ] Sepet → sipariş oluşturma; stok rezervasyonu.
- [ ] Sipariş durum makinesi: Oluşturuldu → Ödendi → Hazırlanıyor → Kargoda → Teslim edildi / İptal.
- [ ] Ödeme: Açık kararlar #2'ye göre (havale/kapıda ödeme veya sağlayıcı sandbox'ı).
- [ ] Yönetici sipariş uçları: listeleme, detay, durum güncelleme, kargo takip numarası.

### 4.3 Pazaryeri entegrasyon modülü
- [ ] Soyutlama: `IMarketplaceProvider` (ürün yayınla, fiyat/stok gönder, sipariş çek, statü güncelle); Trendyol ilk implementasyon. N11 ileride aynı arayüze eklenir.
- [ ] **Ürün eşleştirme:** yerel ürün/varyant ↔ Trendyol barkodu; yerel kategori ↔ Trendyol kategorisi + özellik eşlemesi.
- [ ] **Yayınlama:** yerel üründen Trendyol ürün isteği üretme; durum (bekliyor / onaylandı / hatalı) takibi.
- [ ] **Tek stok ve fiyat:** yerelde stok/fiyat değişince outbox kaydı → arka plan işçisi Trendyol'a toplu gönderir (rate limit'e uygun).
- [ ] **Sipariş içe alma:** Trendyol siparişleri yerel siparişe dönüştürülür (kanal = Trendyol); stok düşer; idempotent (aynı paket iki kez işlenmez).
- [ ] **Statü geri bildirimi:** yerelde "Hazırlanıyor/Kargoda" olan Trendyol siparişi için Trendyol'a Picking/Invoiced gönderilir.
- [ ] Senkron logu ve tekrar deneme uçları.

**Kabul:** Bir ürün yerelde oluşturulup Trendyol'a yayınlanabiliyor; stok yerelden değişince Trendyol'a yansıyor; hem siteden hem Trendyol'dan gelen siparişler tek listede, ortak stoğu düşürüyor.

---

## Faz 5 — Docker ile yayın (3–4 gün)

- [ ] Multi-stage `Dockerfile` (API), non-root kullanıcı, health check.
- [ ] `docker-compose.yml`: API + SQL Server (+ opsiyonel Seq) ve kalıcı volume'ler (veritabanı, görseller).
- [ ] Migration'lar ayrı bir başlangıç adımı/komutu ile uygulanır.
- [ ] Reverse proxy + HTTPS (Caddy veya Nginx + Let's Encrypt).
- [ ] Ortam konfigürasyonu: `.env` / Docker secrets; Trendyol Prod/Stage seçimi.
- [ ] CI: image build + registry'ye push (GHCR); sunucuda `docker compose pull && up -d`.
- [ ] Veritabanı yedekleme betiği.
- [ ] Sunucu çıkış IP'sinin Trendyol stage whitelist'ine eklenmesi; Trendyol webhook'unun açılması (Faz 3.4).

**Kabul:** Temiz bir sunucuda tek komutla ayağa kalkıyor; health check yeşil; yedekten geri dönüş denenmiş.

---

## Faz 6 — Front-end (React veya Vue) (kapsama göre 15–25 gün)

- [ ] Ayrı repo veya `frontend/` klasörü; Vite + TypeScript.
- [ ] API client'ı OpenAPI'den otomatik üretilir.
- [ ] **Yönetim paneli:** giriş, dashboard, katalog, siparişler (tüm kanallar), Trendyol yayın/eşleştirme ekranları, senkron logu.
- [ ] **Vitrin:** ürün listeleme/detay, sepet, ödeme, müşteri hesabı.
- [ ] Docker image'ı ve compose'a eklenmesi.

---

## Özet takvim

| Faz | İçerik | Süre |
|---|---|---|
| 0 | Güvenlik, derleme, .NET 10 | 1 gün |
| 1 | API projesi, altyapı, test altyapısı | 6–8 gün |
| 2 | Giriş ve güvenlik | 4–5 gün |
| 3 | Trendyol ürün + sipariş | 8–11 gün |
| 4 | Yerel e-ticaret + entegrasyon | 13–18 gün |
| 5 | Docker ile yayın | 3–4 gün |
| 6 | Front-end | 15–25 gün |

Back-end (Faz 0–5): yaklaşık **7–9 hafta**. Front-end dahil: **10–14 hafta**.

---

## Açık kararlar

1. **React mı Vue mu?** Faz 6'ya kadar gerekmiyor. Yönetim paneli ve vitrin tek uygulama mı, iki ayrı uygulama mı olacak? (Vitrin için SEO önemliyse Next.js/Nuxt gibi SSR değerlendirilir.)
2. **Ödeme:** MVP'de havale/kapıda ödeme mi, yoksa iyzico/PayTR gibi bir sağlayıcı mı? Sağlayıcı Faz 4'e +3–5 gün ekler.
3. **Görsel depolama:** Docker volume + reverse proxy üzerinden servis etmek (basit) mi, S3 uyumlu nesne depolama/CDN mi?
4. **Yayın hedefi:** VPS (Hetzner/DigitalOcean vb.) varsayıldı.

## Alınan kararlar

| Tarih | Karar |
|---|---|
| 2026-11-06 | Tek satıcı, SaaS değil. Back-end ve front-end ayrı projeler; front-end en son (React veya Vue). |
| 2026-11-06 | Mapping: AutoMapper kaldırılır, **Mapster** kullanılır. |
| 2026-11-06 | DI: Autofac + Castle interceptor'ları kaldırılır, **.NET'in yerleşik DI**'ı kullanılır. |
| 2026-11-06 | Test framework'ü: **xUnit**. |
