using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
//app.MapGet("/user", () => new {name = "Bernardo Druziki", Age = 19}); //GET É O METODO DE ACESSO.

app.MapPost("/saveproduct", (Product product) => { //SALVAR O PRODUTO.
    ProductRepository.Add(product);
});

app.MapGet("/getproduct/{code}", ([FromRoute] string code) => { //VISUALIZAR(OU OBTER) O PRODUTO SALVO.
    var product = ProductRepository.GetBy(code);
    return product;
});

app.MapPut("/editproduct", (Product product) => { //EDITAR PRODUTO.
    var productSaved = ProductRepository.GetBy(product.Code);
    productSaved.Name = product.Name;
});

app.MapDelete("/deleteproduct/{code}", ([FromRoute] string code) => { //DELETAR PRODUTO.
    var productSaved = ProductRepository.GetBy(code);
    ProductRepository.Remove(productSaved);
});
////////////////////////////////////////////////////////


app.MapPost("/saveuser", (Client client) => { //SALVAR O USER.
    UserRepository.Add(client);
});

app.MapGet("/getuser/{code}", ([FromRoute] string code) => { //VISUALIZAR(OU OBTER) O USER SALVO.
    var user = UserRepository.GetBy(code);
    return user;
});

app.MapPut("/edituser", (Client client) => { //EDITAR USER.
    var userSaved = UserRepository.GetBy(client.Code);
    userSaved.userName = client.userName;
});

app.MapDelete("/deleteuser/{code}", ([FromRoute] string code) => { //DELETAR USER.
    var userSaved = UserRepository.GetBy(code);
    UserRepository.Remove(userSaved);
});
app.Run();

public static class ProductRepository //FONTE DE DADOS
{
    public static List <Product> Products { get; set; }

    public static void Add(Product product) //ADD PRODUTO
    {
        if(Products == null)
            Products =  new List<Product>();

        Products.Add(product);
    }

    public static Product GetBy(string code) //PEGAR (GET) PELO CÓDIGO (CODE).
    {
        return Products.FirstOrDefault(p => p.Code == code); 
    }

    public static void Remove(Product product)
    {
        Products.Remove(product);
    }
}
////////////////////////////////////////////


public static class UserRepository //FONTE DE DADOS
{
    public static List <Client> Clients { get; set; }

    public static void Add(Client client) //ADD PRODUTO
    {
        if(Clients == null)
            Clients =  new List<Client>();

        Clients.Add(client);
    }

    public static Client GetBy(string code) //PEGAR (GET) PELO CÓDIGO (CODE).
    {
        return Clients.FirstOrDefault(p => p.Code == code); 
    }

    public static void Remove(Client client)
    {
        Clients.Remove(client);
    }
}


public class Product 
{
    public string Code { get; set; }
    public string Name { get; set; }

}

 public class Client
{
     public string userName { get; set; }

     public string Code { get; set; }

}
