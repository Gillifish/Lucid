

public class Account {

    public int id {get; set;}
    public string AccountName {get; set;}

    public string Username {get; set;}

    public string Password {get; set;}

    public override string ToString()
    {
        return $"{AccountName},\n{Username},\n{Password}";
    }

}