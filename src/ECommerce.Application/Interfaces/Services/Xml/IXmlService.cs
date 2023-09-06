using ECommerce.Core.Application;
using ECommerce.Product;
using ECommerce.Systems;

namespace ECommerce.Xml;

public interface IXmlService
{
    IDataResult<GnlProductXml> AddXml(GnlProductXml xml);
    IResult UpdateXml(GnlProductXml xml);
    IResult DeleteXml(int id);
    IListResult<GnlProductXml> GetAllXml();
    IListResult<GnlProductXml> GetXmls(string xmlLink = "", int statusId = (int)StatusTypes.All);
    IListResult<GnlProductXml> GetXml(int xmlId);
}
