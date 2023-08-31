using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceNetCore.Domain.Common
{
    public static class UserConsts
    {
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string UserAlreadyExist = "Kullanıcı zaten var.";
        public const string LoginSuccesful = "Giriş başarılı.";
        public const string LoginFailed = "Giriş başarısız.";
        public const string PasswordIncorrect = "Parola hatalı.";
        public const string UserDoesNotSave = "Kullanıcı kaydedilemedi.";
        public const string UserSuccessfullyCreated = "Kullanıcı başarıyla oluşturuldu.";
    }
}
