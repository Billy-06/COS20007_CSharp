//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_ROVER_H
#define ROVERPROJECT_ROVER_H

#include <vector>
#include "Battery.h"
#include "Device.h"

using namespace std;

class Rover 
{

private:
    vector<Battery*> _batteries;
    vector<Device*> _devices;

public:
    Rover();
    Rover(const Rover& another);
    ~Rover();
    void operator=(const Rover& other);
    int deviceCount();
    int batteryCount();
    void attachDevice(Device* device);
    void attachBattery(Battery* battery);

};


#endif //ROVERPROJECT_ROVER_H
