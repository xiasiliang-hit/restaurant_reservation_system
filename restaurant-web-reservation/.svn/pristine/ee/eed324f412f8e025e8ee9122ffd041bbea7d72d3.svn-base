#pragma once

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <math.h>
#include <stdbool.h>

#define TOTAL_PROTEINS 84652//8825//9323//12235 //从select 文件中出现 //14066: 2815个表型从原始gene->蛋白质中提取的
#define TOTAL_PHENOTYPES 1897//2042 //去掉无蛋白质关连，去掉H,G区间表示的,剩余在select文件
//2801 从gene关联到蛋白质后，有蛋白质关联的表型数量
//2815 //morbidMap中所有的表型号

#define PROTEIN_LENGTH 16 //蛋白质名的长度
#define PHENOTYPE_LENGTH 7 //表型名的长度
#define GENE_LENGTH 7 //表型名的长度

#define CAUSE_PROTEINS 256 //蛋白质关联 148
#define CAUSE_LOCATIONS 64 //表型引起区间30
//#define LINE_LENGTH 4096


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

#define CATAGORY 6
#define TER 7 //3位全1
#define UNNORMAL_POS 0

#define TOTAL_MORBIDLOCS 3320//2488//2646 //区间关联总数
#define TOTAL_PHENOTYPEPROTEINS 14002//14962 //蛋白质关联总数，后验

#define TOTAL_PROTEIN_SIMILARITY 3018468//3281414 //蛋白质相似度项的个数

#define TOTAL_PHENOTYPEMATCHPROTEINS 1423371//1260528

//蛋白质
typedef struct
{
	char chName[PROTEIN_LENGTH];
	int iID;
}Protein;

//表型
typedef struct
{
	char chName[PHENOTYPE_LENGTH];
	int iID;
}Phenotype;

//指向真关系数组的头指针和偏移量，指明当前表型其引起蛋白质的数量和真关系数组中所在的位置
typedef struct PhenotypeProteinPointer
{
	int start;
	int offset;
}PhenotypeProteinPointer;

//蛋白质位点
typedef struct ProteinLoc
{
	//char chName[16];
	unsigned int pos;
	int maskPos; //指明精确度的掩码在mask数组中的位置，
} ProteinLoc;

//表型区间
typedef struct MorbidLoc
{
	unsigned int start;
	unsigned int end;
	int maskPosStart;
	int maskPosEnd;
} MorbidLoc;

//表型
typedef struct MorbidLocPointer
{
	int start;
	int offset;
}MorbidLocPointer;

//蛋白质相似度项
typedef struct ProteinSimilarityItem
{
	int proteinAID;
	int proteinBID;
	float similarity;
} ProteinSimilarityItem;

//区间匹配蛋白质数组指针
typedef struct PhenotypeMatchProteinPointer
{
	int start;
	int offset;
}PhenotypeMatchProteinPointer;

extern const unsigned int mask[CATAGORY];  //获取到特定染色体区间精确度的掩码数组

extern Protein TotalProteins[TOTAL_PROTEINS]; //所有蛋白质索引
extern Phenotype TotalPhenotypes[TOTAL_PHENOTYPES];  //所有表型索引

extern int proteinSimiIndexs[TOTAL_PROTEINS]; //蛋白质相似度索引数组
extern ProteinSimilarityItem proteinSimilarity[TOTAL_PROTEIN_SIMILARITY]; //蛋白质相似度数组
//extern float proteinSimilarity[TOTAL_PROTEINS][TOTAL_PROTEINS];  //蛋白质相互作用矩阵

extern float phenotypesSimilarity[TOTAL_PHENOTYPES][TOTAL_PHENOTYPES];  //表型相似度举证
extern int TotalPhenotypeProtein[TOTAL_PHENOTYPEPROTEINS];  //真关系数组，存表型引起蛋白质的程序内编号
	extern PhenotypeProteinPointer pointerPhenotypeProteins[TOTAL_PHENOTYPES];  //真关系蛋白质数组位置指针数组,指明真关系蛋白质在数组TotalPhenotypeProtein中的位置和真关系蛋白质总数量
extern float interactionMatrix[TOTAL_PROTEINS][TOTAL_PHENOTYPES];  //计算矩阵

extern ProteinLoc TotalProteinLocs[TOTAL_PROTEINS];  //蛋白质区间数组
extern MorbidLoc TotalMorbidLocs[TOTAL_MORBIDLOCS];  //表型区间数组
	extern MorbidLocPointer pointerMorbidLocs[TOTAL_PHENOTYPES];  //表型区间数组位置指针数组，指明表型区间在数组TotalMorbidLocs中的开始位置和区间总数量

extern int TotalPhenotypeMatchProtein[TOTAL_PHENOTYPEMATCHPROTEINS];
	extern PhenotypeMatchProteinPointer pointerPhenotypeMatchProtein[TOTAL_PHENOTYPES];

extern const char* selectedFile;
extern const char* pchProteinIDFile;
extern const char* pchPhenotypeIDFile;

extern const char* proteinSimilarityFileBin;
extern const char* phenotypeSimilarityFileBin;
//const char* pchPhenotypeProteinRelationFile = "Data\\phenotypeProtein.bin";
extern const char* interactionMatrixFileBin;

extern const char* proteinIDFileBin;
extern const char* phenotypeIDFileBin;

extern const char* phenotypeProteinFilebin;
extern const char* pointerPhenotypeProteinFileBin;

extern const char* proteinLocsFileBin;
extern const char* phenotypeLocsFileBin;
extern const char* phenotypeLocsPointerFileBin;
//extern const float fPrecesion;

extern const char* phenotypeMatchProteinFileBin;
extern const char* pointerPhenotypeMatchProteinFileBin;

void InitialFromBinary();

int ProteinNameToID(const char* pchName);
char* ProteinIDToName(int iID);
int PhenotypeNameToID(const char* pchName);
char* PhenotypeIDToName(int iID);

void MsgFunction(const char* pStr);
void MsgRead(const char* pStr);
void MsgWrite(const char* pStr);
void MsgError(const char* pStr);
void MsgUnknownError(const char* pStr);

bool isLocationMatch2(const MorbidLoc pM, const ProteinLoc pP);
char* BitToLocation(unsigned int bit);
