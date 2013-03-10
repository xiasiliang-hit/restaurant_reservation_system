#pragma once

#include "Global.h"
#include "Phenotype.h"

#define simiMax 5192686//5111496 //相似度文件protein.links行数
typedef struct Simi
{
	char first[PROTEIN_LENGTH];
	char second[PROTEIN_LENGTH];

	int mark;
} Simi;

void CreateProteinSimilarityFile();

void ReadProteinMap(ProteinMap* pProteinMaps, Protein* pProtein, int pSize);
int ProteinCompare(const void* pA, const void* pB);

void NormalizeProteinSimilarity();
