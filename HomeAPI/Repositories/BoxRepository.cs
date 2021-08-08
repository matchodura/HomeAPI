using HomeAPI.Data;
using HomeAPI.Helpers;
using HomeAPI.Interfaces;
using HomeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAPI.Repositories
{
    public class BoxRepository : IBoxRepository
    {
        private readonly HomeContext _context;

        public BoxRepository(HomeContext context)
        {
            _context = context;
        }

        public Box CreateBox(Box box)
        {

            DateTime currentDateTime = DateTime.Now;

            box.DateCreated = currentDateTime;
            box.DateModified = currentDateTime;
                       
            _context.Add(box);
            _context.SaveChanges();

            int boxId = box.ID;

            List<DHT> dhts = _context.DHTs.Where(d => d.DeviceID == box.DHTId).ToList();
            List<MotionSensor> motionSensors = _context.MotionSensors.Where(d => d.DeviceID == box.MotionSensorId).ToList();

            foreach (DHT dht in dhts)
            {
                dht.BoxId = boxId;
                dht.DateCreated = currentDateTime;
                dht.DateModified = currentDateTime;
                _context.Update(dht);
                _context.SaveChanges();
            }

            foreach (MotionSensor motionSensor in motionSensors)
            {
                motionSensor.BoxId = boxId;
                motionSensor.DateCreated = currentDateTime;
                motionSensor.DateModified = currentDateTime;
                _context.Update(motionSensor);
                _context.SaveChanges();
            }

            _context.SaveChanges();

            return box;
        }

        public bool DeleteBox()
        {
            throw new NotImplementedException();
        }

        public List<Box> GetAllBoxes()
        {
            throw new NotImplementedException();
        }

        public Box GetBoxById(int boxId)
        {
            throw new NotImplementedException();
        }

        public Box GetBoxByName(string boxName)
        {
            throw new NotImplementedException();
        }            

        public List<MotionSensor> GetMotionSensors()
        {
            return _context.MotionSensors.Distinct().ToList();
        }

        // to be completed
        public Box UpdateBox(Box box)
        {


            DateTime currentDateTime = DateTime.Now;
                      
            box.DateModified = currentDateTime;

            _context.Add(box);
            _context.SaveChanges();

            int boxId = box.ID;

            List<DHT> dhts = _context.DHTs.Where(d => d.DeviceID == box.DHTId).ToList();
            List<MotionSensor> motionSensors = _context.MotionSensors.Where(d => d.DeviceID == box.MotionSensorId).ToList();

            foreach (DHT dht in dhts)
            {
                dht.BoxId = boxId;
                dht.DateCreated = currentDateTime;
                dht.DateModified = currentDateTime;
                _context.Update(dht);
                _context.SaveChanges();
            }

            foreach (MotionSensor motionSensor in motionSensors)
            {
                motionSensor.BoxId = boxId;
                motionSensor.DateCreated = currentDateTime;
                motionSensor.DateModified = currentDateTime;
                _context.Update(motionSensor);
                _context.SaveChanges();
            }

            _context.SaveChanges();

            return box;
        }

      
    }
}
