namespace LOFI.ApiMomoModel;

public class RequestToPayModel
{
    public string amount { get; set; }
    public string currency { get; set; }
    public string externalId { get; set; }
    public string payerMessage { get; set; }
    public string payeeNote { get; set; }
    public virtual Payer Payer { get; set; }
}

public class Payer
{
    public string partyIdType { get; set; } = "MSISDN";
    public string partyId { get; set; }
}
