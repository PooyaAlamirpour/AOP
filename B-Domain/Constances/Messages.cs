using System;
using System.ComponentModel;
using Entities.Concretes;
using Humanizer;

namespace Domain.Constances
{
    public static class Messages
    {
        public static readonly string ProductIsAddedSuccessfully =
            nameof(ProductIsAddedSuccessfully).Humanize(LetterCasing.Sentence);

        public static readonly string ProductIsDeletedSuccessfully =
            nameof(ProductIsDeletedSuccessfully).Humanize(LetterCasing.Sentence);

        public static readonly string ProductIsUpdatedSuccessfully =
            nameof(ProductIsUpdatedSuccessfully).Humanize(LetterCasing.Sentence);

        public static readonly string ProductAlreadyExist = nameof(ProductAlreadyExist).Humanize(LetterCasing.Sentence);

        public static readonly string UserIsNotFound = nameof(UserIsNotFound).Humanize(LetterCasing.Sentence);
        public static readonly string PasswordError = nameof(PasswordError).Humanize(LetterCasing.Sentence);
        public static readonly string SuccessfullyLogin = nameof(SuccessfullyLogin).Humanize(LetterCasing.Sentence);
        public static readonly string UserAlreadyExists = nameof(UserAlreadyExists).Humanize(LetterCasing.Sentence);
        public static readonly string UserIsRegistered = nameof(UserIsRegistered).Humanize(LetterCasing.Sentence);
        public static readonly string AccessTokenIsCreated = nameof(AccessTokenIsCreated).Humanize(LetterCasing.Sentence);

        public static readonly string PleaseLogin =
            "Please login for using this service. It is used JWT for authentication.".Truncate(15, "...");
        
        public static string TestEnum = UserState.Blocked.Humanize();                       // Returns the description
        public static string TestDateTime1 = DateTime.UtcNow.AddHours(-24).Humanize();       // Yesterday
        public static string TestDateTime2 = DateTime.UtcNow.AddMinutes(70).Humanize();       // An hour from now
        
        private enum UserState
        {
            [Description("The use is blocked. Call the supporter.")]
            Blocked,
            Activated
        }
    }
}