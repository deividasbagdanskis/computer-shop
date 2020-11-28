using System.ComponentModel;

namespace ComputerShop.Enums
{
    public enum Status
    {
        [Description("Awaiting Fulfillment")] AwaitingFulfillment,
        [Description("Awaiting Shipment")] AwaitingShipment,
        Shipped,
        Completed
    }
}
