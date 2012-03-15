using System;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace QX.Model
{
   [Serializable]
   public partial class CC_Movement
   {
      private decimal cCM_ID;
      private bool cCM_ID_IsChanged=false;
      public decimal CCM_ID
      {
         get{ return cCM_ID; }
         set{ cCM_ID = value; cCM_ID_IsChanged=true; }
      }
      public bool CCM_ID_IsChanged
      {
         get{ return cCM_ID_IsChanged; }
         set{ cCM_ID_IsChanged = value; }
      }
   }
}
