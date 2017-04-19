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
        public delegate void pointDelegate(double points);
        public event pointDelegate OnTick;

        private double trueInterval; // seconds
        private int intInterval; // rounded seconds
        private double points;
        private double pointsPerInterval;

        private static object lockObj;

        public PointCounter()
        {
            lockObj = new object();
        }

        public void Initialize()
        {
            points = 0;
            trueInterval = 1000;
            intInterval = 1000;
            pointsPerInterval = 1;

            Thread countThread = new Thread(Count);
            countThread.Start();
        }

        private void Count()
        {
            while (true)
            {
                Thread.Sleep(intInterval);
                AddPoints();
                OnTick?.Invoke(points);
            }
        }

        private void AddPoints()
        {
            points += pointsPerInterval;
        } 

        public double GetPoints()
        {
            return points;
        }

        public void IncreasePointsPerInterval(double value)
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

        public void DecreasePoints(double value)
        {
            lock(lockObj)
            {
                points -= value;
            }
        }
    }
}
