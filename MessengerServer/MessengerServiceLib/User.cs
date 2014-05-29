using System;

namespace MessengerServiceLib
{
    /// <summary>
    /// Пользователь чата
    /// </summary>
    [Serializable]
    public class User
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Признак нахождения в сети: TRUE - в сети, FALSE - не в сети
        /// </summary>
        public bool Online { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }

        public User(int id, string username, bool online)
        {
            Id = id;
            Username = username;
            Online = online;
        }

        protected bool Equals(User other)
        {
            return string.Equals(Username, other.Username) && Online.Equals(other.Online) && Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((User) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (Username != null ? Username.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ Online.GetHashCode();
                hashCode = (hashCode*397) ^ Id;
                return hashCode;
            }
        }
    }
}