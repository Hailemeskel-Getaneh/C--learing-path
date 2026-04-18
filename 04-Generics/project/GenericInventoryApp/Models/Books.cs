using GenericInventoryApp.Interfaces;


namespace GenericInventoryApp.Models {

    public class Book : IEntity {
        
        public int Id {get; set;}
        public string? Title {get; set;}

        public override string ToString(){
            
            return $"{Id} : {Title}";
        }
    }
}