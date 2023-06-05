using WebApplication1.Dto;

namespace WebApplication1.Store
{
    public class ValueStore
    {
        public static List<ValueDto> valueList = new List<ValueDto>
        {
            new ValueDto{ id = 1, name = "remera", description = "linda remera", price = 100, img = "ok", quantity = 0 },
            new ValueDto{ id = 2, name = "pantalon", description = "linda pantal", price = 200, img = "ok", quantity = 0 },
            new ValueDto{ id = 3, name = "chomba", description = "linda chomba", price = 300, img = "ok", quantity = 0 }
        };
    }
}
