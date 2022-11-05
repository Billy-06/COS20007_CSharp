//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_DEVICE_H
#define ROVERPROJECT_DEVICE_H

#include "Battery.h"
#include <string>
#include <iostream>

using namespace std;

class Device {
protected:
    Battery* _battery;

public:
    Device();
    Device(const Device& item);
//    Device&( Device&& other);
    ~Device();
    // = operator to assign an object to another
    Device& operator=(const Device& item);

    bool hasBattery();
    virtual string operate();


};


#endif //ROVERPROJECT_DEVICE_H
