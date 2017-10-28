using System;

namespace EzGPA.Localization
{
    public class LocaleInfo : IEquatable<LocaleInfo>
    {
        private readonly string _id;
        private readonly string _name;

        public string Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public LocaleInfo(string id, string name)
        {
            if (id == null)
                throw new ArgumentNullException("id");
            if (name == null)
                throw new ArgumentNullException("name");
            _id = id;
            _name = name;
        }

        public bool Equals(LocaleInfo other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_id, other._id);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as LocaleInfo);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Id);
        }
    }
}
