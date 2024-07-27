using Actions.Entities;

namespace Actions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            // Chamando o método action direto
            list.ForEach(UpdatePrice);

            // instanciando um action, atribuindo o método a ele e chamando a instancia
            Action<Product> action = UpdatePrice;
            list.ForEach(action);

            // atribuindo uma expressão lambda à instancia do action
            Action<Product> action2 = p => { p.Price += p.Price * 0.1; };
            list.ForEach(action2);

            // Colocando a expressão inline no método Foreach
            list.ForEach(p => { p.Price += p.Price * 0.1; });

        }

        static void UpdatePrice(Product p)
        {
            p.Price += p.Price * 0.1;
        }
    }
}
