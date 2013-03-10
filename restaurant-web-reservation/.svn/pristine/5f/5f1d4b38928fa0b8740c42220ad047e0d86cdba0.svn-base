#pragma once

#include "Global.h"

#define iMaxPhenotype 5080 //PhenotypeSimilarity行数
#define iMaxRowLength 50800
#define simiLength 10

typedef struct
{
	char chName[PHENOTYPE_LENGTH];
	int iIndex;
} PhenotypeIndex;

void CreatePhenotypeSimilarityFile();

void ReadMorbidMap();
int PhenotypeCompare(const void* pA, const void* pB);

void StrToLocation(char* pStr, MorbidMap* pMorbidMap);
unsigned int LocationToBit(char* pChro, char* pBand);
char* BitToLocation(unsigned int bit);
