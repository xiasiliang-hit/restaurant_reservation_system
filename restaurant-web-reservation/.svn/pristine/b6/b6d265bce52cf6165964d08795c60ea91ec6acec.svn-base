#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdbool.h>
#include <limits.h>

#define TOTAL_PROTEIN_SIMILARITY 3018468//3281414 //蛋白质相似度项的个数

#define TOTAL_PROTEINS 84652//9323//12235 //从select 文件中出现，proteinID后验
#define TOTAL_PHENOTYPES 1897//2042 //select文件,phenotypeIDFILE后验
//2801 从gene关联到蛋白质后，有蛋白质关联的表型数量
//2815 //morbidMap中所有的表型号

#define PROTEIN_LENGTH 16 //蛋白质名的长度
#define PHENOTYPE_LENGTH 7 //表型名的长度
#define GENE_LENGTH 7 //表型名的长度

#define CAUSE_PROTEINS 256 //蛋白质关联 148
#define CAUSE_LOCATIONS 64//32 //表型引起区间30
#define LINE_LENGTH 4096


#define CAUSE_PROTEIN_END -1


#define CAUSE_LOCATION_END 0xffffffff

#define MASK_CHRO 0xff000000
#define MASK_ARM 0x00ff0000
#define MASK_SUBONE 0x0000f000
#define MASK_SUBTWO 0x00000f00
#define MASK_SUBTHREE 0x000000f0
#define MASK_SUBFOUR 0x0000000f

#define POS_CHRO 24
#define POS_ARM 16
#define POS_SUBONE 12
#define POS_SUBTWO 8
#define POS_SUBTHREE 4

#define TER 7 //3位全1
#define UNNORMAL_POS 0

typedef struct Protein
{
	char chName[PROTEIN_LENGTH];
	int iID;
}Protein;

typedef struct Phenotype
{
	char chName[PHENOTYPE_LENGTH];
	int iID;
}Phenotype;

typedef struct Gene
{
	char chName[GENE_LENGTH];
	int iID;
}Gene;

typedef struct MorbidMap
{
	char chName [PHENOTYPE_LENGTH];
	unsigned int start;
	unsigned int end;
	bool match;
} MorbidMap;

typedef struct ProteinMap
{
	char chName [PROTEIN_LENGTH];
	unsigned int pos;
	bool match;
} ProteinMap;

typedef struct ProteinSimilarityItem
{
	int proteinAID;
	int proteinBID;
	float similarity;
} ProteinSimilarityItem;

//extern float proteinSimilarity[TOTAL_PROTEINS][TOTAL_PROTEINS];
extern ProteinSimilarityItem proteinSimilarity[TOTAL_PROTEIN_SIMILARITY];
extern int proteinSimiIndexs[TOTAL_PROTEINS];

extern float phenotypesSimilarity[TOTAL_PHENOTYPES][TOTAL_PHENOTYPES];
extern int phenotypeProtein[TOTAL_PHENOTYPES][CAUSE_PROTEINS];
extern float interactionMatrix[TOTAL_PROTEINS][TOTAL_PHENOTYPES];
extern Protein TotalProteins[TOTAL_PROTEINS];
extern Phenotype TotalPhenotypes[TOTAL_PHENOTYPES];

extern MorbidMap TotalMorbidMaps[TOTAL_PHENOTYPES][CAUSE_LOCATIONS];
extern ProteinMap TotalProteinMaps[TOTAL_PROTEINS];

extern const char* selectedFile;
extern const char* pchProteinIDFile;
extern const char* pchPhenotypeIDFile;

extern const char* proteinSimilarityFileBin;
extern const char* phenotypeSimilarityFileBin;
extern const char* interactionMatrixFileBin;

extern const char* proteinIDFileBin;
extern const char* phenotypeIDFileBin;

extern const char* phenotypeProteinFileBin;
extern const char* pointerPhenotypeProteinFileBin;

extern const char* proteinLocsFileBin;
extern const char* phenotypeLocsFileBin;
extern const char* phenotypeLocsPointerFileBin;

void CreateIDBinFile();
void GlobalInit();

int ProteinNameToID(const char* pchName);
char* ProteinIDToName(int iID);
int PhenotypeNameToID(const char* pchName);
char* PhenotypeIDToName(int iID);


void MsgFunction(const char* pStr);
void MsgRead(const char* pStr);
void MsgWrite(const char* pStr);
void MsgError(const char* pStr);
void MsgUnknownError(const char* pStr);

int GeneCompare(const void* pA, const void* pB);

char* ExtractPhenotypeID(const char* line);
char* ExtractGeneID(const char* line);
