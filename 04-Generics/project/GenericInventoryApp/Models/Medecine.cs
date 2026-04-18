using  GenericInventoryApp.Interfaces;

namespace GenericInventoryApp.Models {

    public class Medicine: IEntity {

        public int Id {get; set;}
        public string? Name {get; set;}

        public override string  ToString (){

            return $"{Id} - {Name}";
        }


    }
}