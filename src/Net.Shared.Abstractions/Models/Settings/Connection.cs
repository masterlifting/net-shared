using System.ComponentModel.DataAnnotations;

namespace Net.Shared.Abstractions.Models.Settings
{
    public abstract record Connection
    {
        [Required]
        public string Host { get; set; } = null!;
        [Range(1, 65535)]
        public int Port { get; set; }
        [Required]
        public string User { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
