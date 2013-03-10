#include "Global.h"

#include "Phenotype.h"
#include "Protein.h"
#include "PGRelation.h"

const char* selectedFile = "Data\\mid\\Selected.txt";
const char* pchProteinIDFile = "Data\\mid\\ProteinIDFile.txt";
const char* pchPhenotypeIDFile = "Data\\mid\\PhenotypeIDFile.txt";

const char* proteinSimilarityFileBin = "Data\\proteinSimilarity.bin";
const char* phenotypeSimilarityFileBin = "Data\\phenotypesSimilarity.bin";
const char* interactionMatrixFileBin = "Data\\interactionMatrix.bin";

const char* proteinIDFileBin = "Data\\TotalProteins.bin";
const char* phenotypeIDFileBin = "Data\\TotalPhenotype.bin";

const char* phenotypeProteinFileBin = "Data\\TotalPhenotypeProtein.bin";
const char* pointerPhenotypeProteinFileBin ="Data\\pointerPhenotypeProteins.bin";

const char* proteinLocsFileBin = "Data\\TotalProteinLocs.bin";
const char* phenotypeLocsFileBin = "Data\\TotalMorbidLocs.bin";
const char* phenotypeLocsPointerFileBin = "Data\\pointerMorbidLocs.bin";

//float proteinSimilarity[TOTAL_PROTEINS][TOTAL_PROTEINS];
ProteinSimilarityItem proteinSimilarity[TOTAL_PROTEIN_SIMILARITY];
int proteinSimiIndexs[TOTAL_PROTEINS];
float phenotypesSimilarity[TOTAL_PHENOTYPES][TOTAL_PHENOTYPES];
int phenotypeProtein[TOTAL_PHENOTYPES][CAUSE_PROTEINS];
float interactionMatrix[TOTAL_PROTEINS][TOTAL_PHENOTYPES];
Protein TotalProteins[TOTAL_PROTEINS];
Phenotype TotalPhenotypes[TOTAL_PHENOTYPES];

MorbidMap TotalMorbidMaps[TOTAL_PHENOTYPES][CAUSE_LOCATIONS];
ProteinMap TotalProteinMaps[TOTAL_PROTEINS];

void ReadIDFile()
{
	MsgFunction("ReadIDFile");
	FILE* pFile = NULL;

	MsgRead(pchProteinIDFile);
	if (pFile = fopen(pchProteinIDFile, "r"))
	{
		int step_i = 0;
		for (step_i = 0; step_i < TOTAL_PROTEINS; ++step_i)
		{
			fscanf(pFile, "%s %d", TotalProteins[step_i].chName,
				&(TotalProteins[step_i].iID));
		}
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", pchProteinIDFile);
	}

	MsgRead(pchPhenotypeIDFile);
	if (pFile = fopen(pchPhenotypeIDFile, "r"))
	{
		int step_i = 0;
		for (step_i = 0; step_i < TOTAL_PHENOTYPES; ++step_i)
		{
			fscanf(pFile, "%s %d", TotalPhenotypes[step_i].chName,
				&(TotalPhenotypes[step_i].iID));
		}
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", pchPhenotypeIDFile);
	}
}
void CreateIDBinFile()
{
	MsgWrite(proteinIDFileBin);
	FILE* pFile = fopen(proteinIDFileBin, "wb");
	if (pFile)
	{
		fwrite(TotalProteins, sizeof(Protein), TOTAL_PROTEINS, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(proteinIDFileBin);
	}

	MsgWrite(phenotypeIDFileBin);
	pFile = fopen(phenotypeIDFileBin, "wb");
	if (pFile)
	{
		fwrite(TotalPhenotypes, sizeof(Phenotype), TOTAL_PHENOTYPES, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(phenotypeIDFileBin);
	}
}

void GlobalInit()
{
	ReadIDFile();
	ReadPhenotypeProteinRelationFile();
	ReadProteinMap(TotalProteinMaps, TotalProteins, TOTAL_PROTEINS);
	ReadMorbidMap();
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
	for (step_i = 0; step_i < TOTAL_PROTEINS; ++step_i)
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
	int step_i = 0;
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
	int step_i = 0;
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

int GeneCompare(const void* pA, const void* pB)
{
	return strcmp ((*(Gene*)pA).chName , (*(Gene*)pB).chName);
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

//从line里面解析出" \\d{6} "，就是6位数字，前后各有一个空格
//把6位数字返回出来,没找到对应模式时，返回NULL
char* ExtractPhenotypeID(const char* line)
{
	char* result = (char*)malloc(PHENOTYPE_LENGTH * sizeof(char));
	memset(result,'\0',PHENOTYPE_LENGTH);

	bool isFind = false;

    int i = 0;
	int mark = 0;
	int start_check_number = 0;
	const int length = 6;
	const char* ptr_line = line;
	const char* beg_line = NULL;
	char* ptr_result = result;


	while(*ptr_line != '\0' && isFind == false)
	{
		if(*ptr_line == ' ' && start_check_number == 0)
		{
			start_check_number = 1;
			ptr_line++;
		}
		else
		{}

		if(start_check_number == 1) //此位置是数字字符,并且前面一个字符是空格
		{
			const char* pCheckPoint = ptr_line;
			while( '0' <= (int)*ptr_line && (int)*ptr_line <= '9')
			{
				mark++;
				if(mark == 1)
				{
					beg_line = ptr_line;
				}
				else if(mark == 6)
				{
					isFind = true;
					break;
				}
				else
				{}
				ptr_line++;
			}

			start_check_number = 0;
			ptr_line = pCheckPoint;
		}
		else
		{
			start_check_number = 0;
			mark = 0;
			ptr_line++;
		}
	}

	if (isFind == true && beg_line != NULL)
	{
		for(i = 0;i < length; ++i)
		{
			*ptr_result++ = (char)*beg_line++;
		}
		*ptr_result = '\0';
	}
	else
	{
		free(result);
		result = NULL;
	}

	return result;
}

//从line里面解析出"\\|\\d{6}\\|"，就是6位数字，前后各有一个'|'
//把6位数字返回出来,没找到对应模式时，返回NULL
char* ExtractGeneID(const char* line)
{
	char* result = (char*)malloc(GENE_LENGTH * sizeof(char));
	memset(result,'\0',GENE_LENGTH);

	bool isFind = false;

    int i = 0;
	int mark = 0;
	int start_check_number = 0;
	const int length = 6;
	const char* ptr_line = line;
	const char* beg_line = NULL;
	char* ptr_result = result;

	while(*ptr_line != '\0' && isFind == false)
	{
		if(*ptr_line == '|' && start_check_number == 0) //检测前面的空格
		{
			start_check_number = 1;
			ptr_line++;
		}
		else
		{}

		if(start_check_number == 1) //此位置是数字字符,并且前面一个字符是空格
		{
			const char* checkPoint = ptr_line;
			while ( '0' <= (int)*ptr_line && (int)*ptr_line <= '9')
			{
				mark++;
				if(mark == 1)
				{
					beg_line = ptr_line;
				}
				else if(mark == 6)
				{
					if(*(++ptr_line) == '|') //检测后面的'|'
					{
						isFind = true;
					}
					else
					{
						isFind = false;
					}
					break;
				}
				ptr_line++;
			}

			start_check_number = 0;
			ptr_line = checkPoint;
		}
		else
		{
			start_check_number = 0;
			mark = 0;
			ptr_line++;
		}
	}

	if (isFind == true && beg_line != NULL)
	{
		for(i = 0;i < length; ++i)
		{
			*ptr_result++ = (char)*beg_line++;
		}
		*ptr_result = '\0';
	}
	else
	{
		free(result);
		result = NULL;
	}

	return result;
}
