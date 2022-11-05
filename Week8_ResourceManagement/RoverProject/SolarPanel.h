//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_SOLARPANEL_H
#define ROVERPROJECT_SOLARPANEL_H

#include "Device.h"

class SolarPanel : public Device {
public:
    SolarPanel();
    SolarPanel(const SolarPanel& item);
    ~SolarPanel();
    SolarPanel& operator=(const SolarPanel& item);
    string operate() override;
};


#endif //ROVERPROJECT_SOLARPANEL_H
