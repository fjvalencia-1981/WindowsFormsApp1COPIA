using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WS_itec2.clases.model
{
    public class Header
    {
        public int certificateNumber { get; set; }
        public string customerCardNumber { get; set; }
        public string countyOfOriginCoverageCode { get; set; }
        public int labelType { get; set; }
        public string marketplaceRut { get; set; }
        public string sellerRut { get; set; }
    }

    public class Address
    {
        public int addressId { get; set; }
        public string countyCoverageCode { get; set; }
        public string streetName { get; set; }
        public int streetNumber { get; set; }
        public string supplement { get; set; }
        public string addressType { get; set; }
        public bool deliveryOnCommercialOffice { get; set; }
        public string observation { get; set; }
    }

    public class Contact
    {
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string mail { get; set; }
        public string contactType { get; set; }
    }

    public class Package
    {
        public string weight { get; set; }
        public string height { get; set; }
        public string width { get; set; }
        public string length { get; set; }
        public string serviceDeliveryCode { get; set; }
        public string productCode { get; set; }
        public string deliveryReference { get; set; }
        public string groupReference { get; set; }
        public string declaredValue { get; set; }
        public string declaredContent { get; set; }
        public bool extendedCoverageAreaIndicator { get; set; }
    }

    public class Detail
    {
        public List<Address> addresses { get; set; }
        public List<Contact> contacts { get; set; }
        public List<Package> packages { get; set; }
    }

    public class ChileExpress
    {
        public Header header { get; set; }
        public List<Detail> details { get; set; }
    }
}
