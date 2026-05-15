using ProductSupplier.Domain.Common;

namespace ProductSupplier.Domain.Entities {

    public class Supplier:BaseEntity {

        public string CompanyName {get; private set;} = string.Empty;
        public string Email {get; private set;} = string.Empty;
        public string Phone { get; private set;} = string.Empty;
        public string Address {get; private set;} = string.Empty;

        //collection navigation , also used as navigation
        public ICollection<Product> Products  {get; private set;} = new List<Product>();

        public Supplier(string companyName, string email, string phone, string address){
                
                   setName(companyName);
                   setEmail(email);
                   setPhone(phone);
                   setAddress(address);
        }

        // private constructor needed by EF Core

        private Supplier(){

        }

        // Bussiness methods

        public void setName( string name){

            if(string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Company Name is Required");
            if(name.Length > 150)
                    throw new ArgumentException("Name is too long");

             CompanyName = name;
        }

        public void setEmail(string email){

            if(string.IsNullOrWhiteSpace(email))
                 throw new ArgumentException("Email is Required");
                 
         if(!email.Contains("@"))
           throw new ArgumentException("Invalid email format");
            
            Email = email;
        }

        public void setPhone(string phone){

            if(string.IsNullOrWhiteSpace(phone))
                    throw new ArgumentException("Phone number is required");
                
            if(phone.Length < 5)
                    throw new ArgumentException("Phone is too short");

            Phone = phone;           
        }

        public void setAddress(string address){

            if(string.IsNullOrWhiteSpace(address))
                    throw new ArgumentException("Address is Required");

            Address = address;
            
        }
    }
}