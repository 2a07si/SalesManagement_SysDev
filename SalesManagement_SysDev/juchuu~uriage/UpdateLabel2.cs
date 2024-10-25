using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesManagement_SysDev.juchuu_uriage
{
    public class UpdateLabel2 : Label, Updator
    {

        public void UpdateEvent(object sender)
        {

            if (sender is UpdatorButton)
            {

                BackColor = Color.Red;

            }

        }

    }

    public interface Updator
    {

        void UpdateEvent(object sender);

    }

    public class UpdatorButton : Button
    {

        private List<Updator> updators = new List<Updator>();

        public void OnUpdate()
        {

            foreach (Updator updator in updators)
            {

                updator.UpdateEvent(this);

            }

        }

        public UpdatorButton AddUpdator(Updator updator)
        {

            updators.Add(updator);

            return this;

        }

    }

}
