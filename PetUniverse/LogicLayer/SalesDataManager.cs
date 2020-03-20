using DataTransferObjects;
using DataAccessInterfaces;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LogicLayer
{
	public class SalesDataManager : ISalesDataManager
	{
		private ISalesDataAccessor _salesDataAccessor;

		public SalesDataManager()
		{
			_salesDataAccessor = new SalesDataAccessor();
		}

		public SalesDataManager(ISalesDataAccessor salesDataAccessor)
		{
			_salesDataAccessor = salesDataAccessor;
		}

		public List<SalesDataVM> RetrieveAllTotalSalesData()
		{
			try
			{
				return _salesDataAccessor.RetrieveAllTotalSalesData();
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Data not found.", ex);
			}
		}
	}
}
