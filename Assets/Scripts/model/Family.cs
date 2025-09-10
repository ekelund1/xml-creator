public class Family
{
    private string name;
    private string born;
    private Address address;
    private Phone phone;

    public string Name { get => name; set => name = value; }
    public string Born { get => born; set => born = value; }
    public Address Address { get => address; set => address = value; }
    public Phone Phone { get => phone; set => phone = value; }
}