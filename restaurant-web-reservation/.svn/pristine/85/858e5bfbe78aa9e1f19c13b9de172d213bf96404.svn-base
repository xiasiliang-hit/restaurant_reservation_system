#include "Global.h"

//const char* selectedFile = "Data\\Selected.txt";
//const char* pchProteinIDFile = "Data\\ProteinIDFile.txt";
//const char* pchPhenotypeIDFile = "Data\\PhenotypeIDFile.txt";

const char* proteinSimilarityFileBin = "Data\\proteinSimilarity.bin";
const char* proteinSimilarityIndex = "Data\\protein.links.index.bin"; //proteinSimilarity index file
const char* phenotypeSimilarityFileBin = "Data\\phenotypesSimilarity.bin";
//const char* pchPhenotypeProteinRelationFile = "Data\\phenotypeProtein.bin";
const char* interactionMatrixFileBin = "Data\\interactionMatrix.bin";

const char* proteinIDFileBin = "Data\\TotalProteins.bin";
const char* phenotypeIDFileBin = "Data\\TotalPhenotype.bin";

const char* phenotypeProteinFileBin = "Data\\TotalPhenotypeProtein.bin";
const char* pointerPhenotypeProteinFileBin ="Data\\pointerPhenotypeProteins.bin";

const char* proteinLocsFileBin = "Data\\TotalProteinLocs.bin";
const char* phenotypeLocsFileBin = "Data\\TotalMorbidLocs.bin";
const char* phenotypeLocsPointerFileBin = "Data\\pointerMorbidLocs.bin";

const char* phenotypeMatchProteinFileBin = "Data\\TotalPhenotypeMatchProtein.bin";
const char* pointerPhenotypeMatchProteinFileBin ="Data\\pointerPhenotypeMatchProteins.bin";

const unsigned int mask[CATAGORY] ={
	MASK_CHRO,
	MASK_CHRO | MASK_ARM,
	MASK_CHRO | MASK_ARM | MASK_SUBONE,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO | MASK_SUBTHREE,
	MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO | MASK_SUBTHREE | MASK_SUBFOUR
};

Protein TotalProteins[TOTAL_PROTEINS];
Phenotype TotalPhenotypes[TOTAL_PHENOTYPES];

int proteinSimiIndexs[TOTAL_PROTEINS];
ProteinSimilarityItem proteinSimilarity[TOTAL_PROTEIN_SIMILARITY];
//float proteinSimilarity[TOTAL_PROTEINS][TOTAL_PROTEINS];
float phenotypesSimilarity[TOTAL_PHENOTYPES][TOTAL_PHENOTYPES];
int TotalPhenotypeProtein[TOTAL_PHENOTYPEPROTEINS];
	PhenotypeProteinPointer pointerPhenotypeProteins[TOTAL_PHENOTYPES];
float interactionMatrix[TOTAL_PROTEINS][TOTAL_PHENOTYPES];

ProteinLoc TotalProteinLocs[TOTAL_PROTEINS];
MorbidLocPointer pointerMorbidLocs[TOTAL_PHENOTYPES];
	MorbidLoc TotalMorbidLocs[TOTAL_MORBIDLOCS];



void InitialFromBinary()
{
	MsgFunction("InitialBinary");
	FILE* pFile = NULL;

	//蛋白质索引
	MsgRead(proteinIDFileBin);
	if (pFile = fopen(proteinIDFileBin, "rb"))
	{
		fread(TotalProteins, sizeof(Protein), TOTAL_PROTEINS, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", proteinIDFileBin);
	}

	//表型索引
	MsgRead(phenotypeIDFileBin);
	if (pFile = fopen(phenotypeIDFileBin, "rb"))
	{
		fread(TotalPhenotypes, sizeof(Phenotype), TOTAL_PHENOTYPES, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", phenotypeIDFileBin);
	}

		//蛋白质相互作用
	MsgRead(proteinSimilarityFileBin);
	if (pFile = fopen(proteinSimilarityFileBin, "rb"))
	{
		fread(proteinSimilarity, sizeof(ProteinSimilarityItem), TOTAL_PROTEIN_SIMILARITY, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", proteinSimilarityFileBin);
	}

	//蛋白质相似度索引
	MsgRead(proteinSimilarityIndex);
	if(pFile = fopen(proteinSimilarityIndex, "rb"))
	{
		fread(proteinSimiIndexs, sizeof(int), TOTAL_PROTEINS, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", proteinSimilarityIndex);
	}

	//表型相似度
	MsgRead(phenotypeSimilarityFileBin);
	if (pFile = fopen(phenotypeSimilarityFileBin, "rb"))
	{
		fread(phenotypesSimilarity, sizeof(float), TOTAL_PHENOTYPES * TOTAL_PHENOTYPES,
			pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", phenotypeSimilarityFileBin);
	}

	//表型其引起蛋白
	MsgRead(phenotypeProteinFileBin);
	if (pFile = fopen(phenotypeProteinFileBin, "rb"))
	{
		fread(TotalPhenotypeProtein, sizeof(int), TOTAL_PHENOTYPEPROTEINS, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", phenotypeProteinFileBin);
	}

	//表型其引起蛋白位置指针
	MsgRead(pointerPhenotypeProteinFileBin);
	if (pFile = fopen(pointerPhenotypeProteinFileBin, "rb"))
	{
		fread(pointerPhenotypeProteins, sizeof(pointerPhenotypeProteins), TOTAL_PHENOTYPES, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", pointerPhenotypeProteinFileBin);
	}

	//蛋白质区间
	MsgRead(proteinLocsFileBin);
	if (pFile = fopen(proteinLocsFileBin, "rb"))
	{
		fread(TotalProteinLocs, sizeof(ProteinLoc), TOTAL_PROTEINS, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", proteinLocsFileBin);
	}
	//表型区间
	MsgRead(phenotypeLocsFileBin);
	if (pFile = fopen(phenotypeLocsFileBin, "rb"))
	{
		fread(TotalMorbidLocs, sizeof(MorbidLoc), TOTAL_MORBIDLOCS, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", phenotypeLocsFileBin);
	}

	//表型引起区间位置指针
	MsgRead(phenotypeLocsPointerFileBin);
	if (pFile = fopen(phenotypeLocsPointerFileBin, "rb"))
	{
		fread(pointerMorbidLocs, sizeof(MorbidLocPointer), TOTAL_PHENOTYPES, pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", phenotypeLocsPointerFileBin);
	}

////////////
	//评分矩阵
	MsgRead(interactionMatrixFileBin);
	if (pFile = fopen(interactionMatrixFileBin, "rb"))
	{
		fread(interactionMatrix, sizeof(float), TOTAL_PROTEINS * TOTAL_PHENOTYPES,
			pFile);
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", interactionMatrixFileBin);
	}

	//区间匹配的蛋白质数组
	MsgRead(phenotypeMatchProteinFileBin);
	if (pFile = fopen(phenotypeMatchProteinFileBin, "rb"))
	{
		fread(TotalPhenotypeMatchProtein, sizeof(int), TOTAL_PHENOTYPEMATCHPROTEINS,
			pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(phenotypeMatchProteinFileBin);
	}

	//区间匹配的蛋白质数组位置指针
	MsgRead(pointerPhenotypeMatchProteinFileBin);
	if (pFile = fopen(pointerPhenotypeMatchProteinFileBin, "rb"))
	{
		fread(pointerPhenotypeMatchProtein, sizeof(PhenotypeMatchProteinPointer), TOTAL_PHENOTYPES,
			pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(pointerPhenotypeMatchProteinFileBin);
	}
}

int ProteinNameToID(const char* pchName)
{
	int iRetValue = -1;
	int step_i = 0;
	for (step_i = 0; step_i < TOTAL_PROTEINS; ++step_i)
	{
		if (!strcmp(TotalProteins[step_i].chName, pchName))
		{
			iRetValue = TotalProteins[step_i].iID;
			break;
		}
	}
	return iRetValue;
}

char* ProteinIDToName(int iID)
{
	char* pchName = NULL;
	int step_i = 0;
	for ( step_i = 0; step_i < TOTAL_PROTEINS; ++step_i)
	{
		if (iID == TotalProteins[step_i].iID)
		{
			pchName = TotalProteins[step_i].chName;
			break;
		}
	}
	return pchName;
}

int PhenotypeNameToID(const char* pchName)
{
	int iRetValue = -1;
	int step_i =0;
	for (step_i = 0; step_i < TOTAL_PHENOTYPES; ++step_i)
	{
		if (!strcmp(TotalPhenotypes[step_i].chName, pchName))
		{
			iRetValue = TotalPhenotypes[step_i].iID;
			break;
		}
	}
	return iRetValue;
}

char* PhenotypeIDToName(int iID)
{
	char* pchName = NULL;
	int step_i =0;
	for (step_i = 0; step_i < TOTAL_PHENOTYPES; ++step_i)
	{
		if (iID == TotalPhenotypes[step_i].iID)
		{
			pchName = TotalPhenotypes[step_i].chName;
			break;
		}
	}
	return pchName;
}


void MsgFunction(const char* pStr)
{
	printf("\n******** ");
	printf("Function: %s\n", pStr);
}

void MsgRead(const char* pStr)
{
	printf("Read file: %s\n", pStr);
}

void MsgWrite(const char* pStr)
{
	printf("Write file: %s\n", pStr);
}

void MsgError(const char* pStr)
{
	printf("Error: %s\n", pStr);
}

void MsgUnknownError(const char* pStr)
{
	printf("UnknownError: %s\n", pStr);
}

bool isLocationMatch2(const MorbidLoc pM, const ProteinLoc pP)
{
	bool isMatch = false;
	unsigned int maskArm = MASK_CHRO | MASK_ARM;

	if (((pP.pos & maskArm) == (pM.end & maskArm) || (pP.pos & maskArm) == (pM.start & maskArm))
	&& pP.pos >= pM.start && pP.pos <= pM.end)
	{
		isMatch = true;
	}

	else if ((pP.pos & mask[pM.maskPosEnd]) == (pM.end & mask[pM.maskPosEnd]) && pM.end == (pM.end & mask[pM.maskPosEnd]))
	{
		isMatch = true;
	}

	else
	{}

	return isMatch;
}

char* BitToLocation(unsigned int bit)
{
	//char result[128];
	char* result = (char*)malloc(128*sizeof(char));

	unsigned int chroBit = (bit & MASK_CHRO) >> POS_CHRO;
	unsigned int armBit = (bit & MASK_ARM) >> POS_ARM;
	unsigned int subOneBit = (bit & MASK_SUBONE) >> POS_SUBONE;
	unsigned int subTwoBit = (bit & MASK_SUBTWO) >> POS_SUBTWO;
	unsigned int subThreeBit = (bit & MASK_SUBTHREE) >> POS_SUBTHREE;
	unsigned int subFourBit = (bit & MASK_SUBFOUR);

	char chroBuf[128];
	char armBuf[128];
	char subOneBuf[128];
	char subTwoBuf[128];
	char subThreeBuf[128];
	char subFourBuf[128];

	itoa(chroBit, chroBuf, 10);
	itoa(armBit, armBuf, 10);
	itoa(subOneBit, subOneBuf, 10);
	itoa(subTwoBit, subTwoBuf, 10);
	itoa(subThreeBit, subThreeBuf, 10);
	itoa(subFourBit, subFourBuf, 10);

	char* chro = chroBuf;
	char* arm = armBuf;
	char* subOne = subOneBuf;
	char* subTwo = subTwoBuf;
	char* subThree = subThreeBuf;
	char* subFour = subFourBuf;


	if (chroBit == 23)
	{
		chro = "X";
	}
	else if (chroBit == 24)
	{
		chro = "Y";
	}
	else if (chroBit == 25)
	{
		chro = "MT";
	}
	else
	{
		chro = chroBuf;
	}


	if (armBit == 1)
	{
		arm = "cen";
	}
	else if (armBit == 2)
	{
		arm = "p";
	}
	else if (armBit == 3)
	{
		arm = "q";
	}
	else
	{
		arm = armBuf;
	}

	char* sub = NULL;
	if (subOneBit == TER )//&& subTwoBit == TER && subThreeBit == TER && subFourBit == TER)
	{
		sub = "ter";
	}
	else
	{
	    strcat(subThree,subFour);

	    strcat(subTwo,".");
	    strcat(subOne,subTwo);

	    sub = strcat(subOne,subThree);

		//sub = subOne + subTwo + "." + subThree + subFour;
	}

    strcpy(result, chro);
    strcat(result, arm);
    strcat(result, sub);

	char* pos = NULL;

	if (chroBit%10 == 0)//chro == 10, 20的不能去0
	{
		pos = strchr(result + 2, '0');
	}
	else
	{
		pos = strchr(result, '0');
	}

	if (pos != NULL)
	{
	    *pos = '\0';

	    if (result[strlen(result)-1] == '.')
		{
			result[strlen(result)-1]  = '\0';
		}
		else
		{}

	}
	else
	{}

	return result;
}
