#pragma once

#include "Global.h"

#define TOTAL_MORBIDLOCS 3320//2646 //表型区间总数，后验
#define CATAGORY 6

typedef struct ProteinLoc
{
	unsigned int pos;
	int maskPos;
} ProteinLoc;

typedef struct MorbidLoc
{
	unsigned int start;
	unsigned int end;
	int maskPosStart;
	int maskPosEnd;
} MorbidLoc;

typedef struct MorbidLocPointer
{
	int start;
	int offset;
}MorbidLocPointer;


extern unsigned int mask[CATAGORY];
extern MorbidLocPointer pointerMorbidLocs[TOTAL_PHENOTYPES];
extern MorbidLoc TotalMorbidLocs[TOTAL_MORBIDLOCS];
extern ProteinLoc TotalProteinLocs[TOTAL_PROTEINS];

void CreateMapFile();
bool isLocationMatch(const MorbidMap pM, const ProteinMap pP);
