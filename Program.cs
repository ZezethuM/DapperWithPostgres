using Npgsql;
using Dapper;
using TryingPostGres;

string connectionString = "Server=tiny.db.elephantsql.com;Port=5432;Database=yadlvyzc;UserId=yadlvyzc;Password=b2NCy-wd_58-hEenzMDVqUJA4VYlNWkJ";

var connection = new NpgsqlConnection(connectionString);
    connection.Open();

string CREATE_PIZZA_TABLE = @"create table if not exists pizza (
	id  serial NOT NULL,
	type  character varying(45) NOT NULL,
	size   character varying(45) NOT NULL,
	price  decimal NOT NULL,
    PRIMARY KEY (id) 
    );";

connection.Execute(CREATE_PIZZA_TABLE);
// connection.Execute(@"truncate table pizza");

connection.Execute(@"
	insert into 
		pizza (type, size, price)
	values 
		(@Type, @Size, @Price);",
	new Object[] {
		new DeboPizzas() {
		Type = "Regina",
		Size = "small",
		Price = 31.75
	}, new DeboPizzas {
		Type = "Regina",
		Size = "medium",
		Price = 51.75
	}, new DeboPizzas {
		Type = "Regina",
		Size = "large",
		Price = 89.75
	}
});
connection.Close();

var pizzas = connection.Query<DeboPizzas>(@"select * from pizza");
Console.WriteLine(pizzas.Count());

var GROUP_BY_SIZE = @"select size as grouping, sum(price) as total from pizza group by size";

var pizzaTotalPerSize = connection.Query<PizzaGrouped>(GROUP_BY_SIZE);

foreach (var pizza in pizzaTotalPerSize)
{
	Console.WriteLine($"size : {pizza.Grouping} - total @ {pizza.Total} ");
}
