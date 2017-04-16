using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GoP_Logic
{
    public class PointCounter
    {
        private double trueInterval; // seconds
        private int intInterval; // rounded seconds
        private double points;
        private double pointsPerInterval;

        public void Initialize()
        {
            points = 0;
            trueInterval = 10000;
            intInterval = 10000;
            pointsPerInterval = 1;

            Thread countThread = new Thread(Count);
            countThread.Start();
        }

        private void Count()
        {
            Thread.Sleep(intInterval);
            AddPoints();
        }

        private void AddPoints()
        {
            points += pointsPerInterval;
        }

        private void IncreasePointsPerInterval(double value)
        {
            pointsPerInterval += value;
        }

        private void DecreaseIntervalByPercent(double value)
        {
            trueInterval -= trueInterval / 100 * value;
            UpdateIntInterval();
        }

        private void DecreaseIntervalByFlatValue(double value)
        {
            trueInterval -= value;
            UpdateIntInterval();
        }

        private void UpdateIntInterval()
        {
            intInterval = Convert.ToInt32(trueInterval);
        }
    }
}
