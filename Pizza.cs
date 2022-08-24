namespace TryingPostGres
{
      public class DeboPizzas
    {
       public string Type {
            get;
            set;
        } = string.Empty;

        public string Size {
            get;
            set;
        } = string.Empty;

        public double Price {
            get;
            set;
        }
    }

      public class PizzaGrouped
    {
        public string Grouping {
            get;
            set;
        } = string.Empty;

        public double Total {
            get;
            set;
        }

        
    }
}