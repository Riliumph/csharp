namespace logger_demo.Hoge
{
    public class Hoge
    {
        private int _id;
        private string _name;

        public Hoge(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public override string ToString()
        {
            return $"Hoge(Id: {Id}, Name: {Name})";
        }
    }
}
