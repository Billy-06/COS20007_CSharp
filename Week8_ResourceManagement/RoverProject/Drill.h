//
// Created by billy on 3/11/2022.
//

#ifndef ROVERPROJECT_DRILL_H
#define ROVERPROJECT_DRILL_H

#include "Device.h"

class Drill : public Device {
private:
    bool _safetyEnabled;

public:
    Drill();
    Drill(const Drill& item);
    ~Drill();

    Drill& operator=(const Drill& item);

    string operate() override;
};


#endif //ROVERPROJECT_DRILL_H
