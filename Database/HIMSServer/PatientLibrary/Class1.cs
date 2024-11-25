namespace PatientLibrary
{
    public class Patient
    {
        public int Id { get; set; }
        public required string name { get; set; }
        public required string code { get; set; }
        public int age { get; set; }
        

        //to have this nullable proberty use ? this
      //  public string ? code { get; set; }
    } 
}
