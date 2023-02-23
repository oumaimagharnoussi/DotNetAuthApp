namespace BackAppPFE.Models
{
    public record ResetPassword
    {
        public string Email { get; set; }
        public string EmailToken { get; set; }
        public string NewPasswrd { get; set; }
        public string ConfirmPasswrd { get; set; }
    }
}
