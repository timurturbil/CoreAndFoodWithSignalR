using System.Collections;

namespace CoreAndFood.Models
{
    public static class ConnectedUser
    {
        public static List<string> Ids = new List<string>();
        public static string selectedUserId = "";
        public static Hashtable htUsers_ConIds = new Hashtable(20);
    }
}
