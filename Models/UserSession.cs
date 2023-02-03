using tahfez.Models;

namespace tahfezKhalid.Models
{
    public class UserSession
    {
        public string userId { get; set; }
        public User user { get; set; }
        public int sessionId { get; set; }
        public Session session { get; set; }
    }
}
