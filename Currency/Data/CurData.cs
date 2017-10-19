using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Currency.Data
{
    public class CurData
    {
        public static ObservableCollection<Cities> getCitiesCurrency()
        {
            ObservableCollection<Cities> lCities = new ObservableCollection<Cities>();
            List<Organizations> lo = CurData.getDataCurrency();

            Cities city = new Cities();
            foreach (var l in lo.GroupBy(x => x.City))
            {
                lCities.Add(new Cities
                {
                    Name = l.Key,
                    organizations = lo.Where(x => x.City == l.Key).ToList()
                });
            }
            return lCities;
        }

        private static List<Organizations> getDataCurrency()
        {
            string uri = "http://resources.finance.ua/ru/public/currency-cash.xml";
            XDocument doc = XDocument.Load(uri, LoadOptions.None);

            XNamespace df = doc.Root.Name.Namespace;

            IEnumerable<XElement> org =
            from el in doc.Root.Elements("organizations").Elements()
            where (string)el.Attribute("org_type") == "1"
            select el;

            IEnumerable<XElement> region =
            from el in doc.Root.Elements("regions").Elements()
            select el;

            IEnumerable<XElement> city =
            from el in doc.Root.Elements("cities").Elements()
            select el;

            IEnumerable<XElement> currencies =
            from el in doc.Root.Elements("currencies").Elements()
            select el;

            List<Organizations> currencyData = new List<Organizations>();
            foreach (XElement elm in org)
            {
                Organizations orgs = new Organizations();
                foreach (XElement el in elm.Descendants())
                {
                    if (el.Name == "currencies")
                        orgs.currencies = getCurrencies(el);

                    if (el.Name == "title" && el.HasAttributes)
                        orgs.Name = el.Attribute("value").Value;

                    if (el.Name == "phone" && el.HasAttributes)
                        orgs.Phone = el.Attribute("value").Value;

                    if (el.Name == "address" && el.HasAttributes)
                        orgs.Adress = el.Attribute("value").Value;

                    if (el.Name == "link" && el.HasAttributes)
                        orgs.Link = el.Attribute("href").Value;

                    if (el.Name == "region" && el.HasAttributes)
                        orgs.Region = region.First(x => x.Attribute("id").Value == el.Attribute("id").Value).Attribute("title").Value;

                    if (el.Name == "city" && el.HasAttributes)
                        orgs.City = city.First(x => x.Attribute("id").Value == el.Attribute("id").Value).Attribute("title").Value;
                }
                currencyData.Add(orgs);
            }

            return currencyData;
        }

        private static List<Currencies> getCurrencies(XElement el)
        {
            List<Currencies> lc = new List<Currencies>();
            try
            {
                foreach (XElement e in el.Elements())
                {
                    lc.Add(new Currencies
                    {
                        ID = e.Attribute("id").Value,
                        BR = Convert.ToDouble(e.Attribute("br").Value.Replace('.', ',')),
                        AR = Convert.ToDouble(e.Attribute("ar").Value.Replace('.', ','))
                    });
                }
            }
            catch (Exception)
            {
            }
            return lc;
        }
    }
}
