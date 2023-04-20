using EUCTest.Enums;
using EUCTest.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;

namespace EUCTest.Utils
{
	public class StaticData
	{
        private static List<SelectListItem>? _countryList;

        /// <summary>
        /// Vrátí lokalizovaný seznam pohlaví pro CB
        /// </summary>
		public static List<SelectListItem> GetSexList(IStringLocalizer localizer)
		{
			return Enum.GetValues<SexEnum>().Select(c => new SelectListItem { Value = ((int)c).ToString(), Text = localizer[c.ToString()] }).ToList();
        }

        /// <summary>
        /// Vrátí lokalizovaný seznam zemí pro CB
        /// </summary>
        public static List<SelectListItem> GetCountryList(EucDatabaseContext db)
        {
            if (_countryList == null)
               _countryList = db.Countries.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

            return _countryList;
        }
    }
}
