using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Service.ExternalServices.APIs.TrendyolClient
{
    public enum ReturnReason
    {
        [Description("Sebep Yok")]
        [CustomerTrendyol("Trendyol")]
        NoReason = 51,

        [Description("Depo Kayıp")]
        [CustomerTrendyol("Trendyol")]
        WarehouseLoss = 101,

        [Description("Çapraz Hatalı")]
        [CustomerTrendyol("Trendyol")]
        CrossDefective = 151,

        [Description("Müşteri İade Kayıp")]
        [CustomerTrendyol("Trendyol")]
        CustomerLostReturn = 201,

        [Description("Modelini beğenmedim")]
        [CustomerTrendyol("Customer")]
        DidntLikeTheModel = 251,

        [Description("Kusurlu ürün gönderildi")]
        [CustomerTrendyol("Customer")]
        DefectiveProductSent = 301,

        [Description("Yanlış ürün gönderildi")]
        [CustomerTrendyol("Customer")]
        WrongProductSent = 351,

        [Description("Vazgeçtim")]
        [CustomerTrendyol("Customer")]
        ChangedMyMind = 401,

        [Description("Diğer")]
        [CustomerTrendyol("Customer")]
        Other = 451,

        [Description("Bedeni küçük geldi")]
        [CustomerTrendyol("Customer")]
        SizeTooSmall = 501,

        [Description("Bedeni büyük geldi")]
        [CustomerTrendyol("Customer")]
        SizeTooLarge = 551,

        [Description("Ürün belirtilen özelliklere sahip değil\t")]
        [CustomerTrendyol("Customer")]
        ProductDoesntMatchSpecifiedFeatures = 651,

        [Description("Yanlış sipariş verdim")]
        [CustomerTrendyol("Customer")]
        OrderedWrongItem = 701,

        [Description("Diğer - Fraud Kaynaklı")]
        [CustomerTrendyol("Trendyol")]
        OtherFraudRelated = 751,

        [Description("Kalitesini beğenmedim")]
        [CustomerTrendyol("Customer")]
        DislikedTheQuality = 1651,

        [Description("Kargo Teslimatı Gecikmesi")]
        [CustomerTrendyol("Trendyol")]
        DelayedDelivery = 1701,

        [Description("Cezalı Onay")]
        [CustomerTrendyol("Trendyol")]
        PenaltyApproval = 2000,

        [Description("Cezasız Onay")]
        [CustomerTrendyol("Trendyol")]
        ApprovalWithoutPenalty = 2001,

        [Description("Teknik Servis Desteği Gerekiyor")]
        [CustomerTrendyol("Trendyol")]
        TechnicalServiceSupportNeeded = 2002,

        [Description("Kullanılmış Ürün Sebepli Red")]
        [CustomerTrendyol("Trendyol")]
        RejectedDueToUsedProduct = 2003,

        [Description("Hijyenik Sebepli Red")]
        [CustomerTrendyol("Trendyol")]
        RejectedDueToHygienicReasons = 2004,

        [Description("Analiz sonucu üretimden kaynaklı sorun yok")]
        [CustomerTrendyol("Trendyol")]
        NoProductionIssueInAnalysis = 2005,

        [Description("Analiz Değişim")]
        [CustomerTrendyol("Trendyol")]
        AnalysisExchange = 2006,

        [Description("Analiz Tamirat")]
        [CustomerTrendyol("Trendyol")]
        AnalysisRepair = 2007,

        [Description("Üründe adet/aksesuar eksiği")]
        [CustomerTrendyol("Trendyol")]
        MissingQuantityAccessory = 2008,

        [Description("Firmaya ait olmayan ürün")]
        [CustomerTrendyol("Trendyol")]
        NotBelongingToCompany = 2009,

        [Description("Tekrar Sevk")]
        [CustomerTrendyol("Trendyol")]
        Resend = 2010,

        [Description("Satıcı Tarafından Aksiyona Çekilen")]
        [CustomerTrendyol("Trendyol")]
        InitiatedBySeller = 2011,

        [Description("İade Süresi Geçmiş")]
        [CustomerTrendyol("Trendyol")]
        ReturnPeriodExpired = 2012,

        [Description("Ürün Müşteride")]
        [CustomerTrendyol("Trendyol")]
        ProductWithCustomer = 2013,

        [Description("Analize Gönder")]
        [CustomerTrendyol("Trendyol")]
        SendForAnalysis = 2014,

        [Description("Teslim edilemeyen gönderi")]
        [CustomerTrendyol("Trendyol")]
        UndeliverableShipment = 2015,

        [Description("Daha iyi bir fiyat mevcut")]
        [CustomerTrendyol("Customer")]
        BetterPriceAvailable = 2030
    }

    public class CustomerTrendyolAttribute : Attribute
    {
        public string Value { get; }

        public CustomerTrendyolAttribute(string value)
        {
            Value = value;
        }
    }
}
