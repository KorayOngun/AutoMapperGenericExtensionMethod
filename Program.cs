using AutoMapper;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
        Mapper mapper = new Mapper(config); 

        

        Person p = new Person();
        p.Id = 1;
        p.Name = "Test name";
        p.LastName = "Test lastName";

        var pn = p.ConvertToDto<PersonName>(mapper);
        Console.WriteLine(pn.Name);

        var pnLn = p.ConvertToDto<PersonNameLastName>(mapper);
        Console.WriteLine(pnLn.Name);
        Console.WriteLine(pnLn.LastName);

    }
}

interface IEntity
{

}

class Person : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }    
}

class PersonName
{
    public string Name { get; set; }
}
class PersonNameLastName
{
    public string Name { get; set; }

    public string LastName { get; set; }

}


static class Extensions
{
    public static T ConvertToDto<T>(this IEntity entity,IMapper mapper)
    {
        return mapper.Map<T>(entity);
    }
}

class MapperProfile : Profile
{
    
    public MapperProfile()
    {
        CreateMap<Person, PersonName>();
        CreateMap<Person, PersonNameLastName>();   
    }
}