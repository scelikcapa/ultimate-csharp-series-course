namespace Amazon
{
    public class GoldCustomer : CustomerAccess
    {
        public void OfferVoucher()
        {
            this.CalculateRatingProtected();
        }
    }
}