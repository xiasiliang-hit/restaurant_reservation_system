#include "Phenotype.h"
#include "Test.h"

static char* pchIndexFile = "Data\\revised\\PhenotypeSimilarityMatrixIndex.txt";
static const char* pchDataFile = "Data\\revised\\PhenotypeSimilarityMatrix.txt";
static const int iMax = 5662;
static const char* morbidMapFile = "Data\\revised\\morbidmap_revised";

static float TotalSimilarity[iMaxPhenotype][iMaxPhenotype];  //all phenotype similartiy in original file
static Phenotype PhenotypeIDIndex[iMaxPhenotype];


void CreatePhenotypeSimilarityFile()
{
	MsgRead(pchIndexFile);

	FILE* fin = fopen(pchIndexFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; i <= iMaxPhenotype - 1; i++)
		{
			char aLine[PHENOTYPE_LENGTH] = {'\0'};
			fscanf(fin, "%s", aLine);

			strcpy(PhenotypeIDIndex[i].chName, aLine);
			PhenotypeIDIndex[i].iID = i;
		}
		fclose(fin);
	}
	else
	{}

	MsgRead(pchDataFile);
	fin = fopen(pchDataFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; i <= iMaxPhenotype - 1; i++)
		{
			int head = 0;
			char aLine[iMaxRowLength+10] = {'\0'};
			fscanf(fin, "%s", aLine);

			int j = 0;
			for (j = 0; j <= iMaxPhenotype - 1; j++)
			{
				char simiStr[simiLength] = {'\0'};
				strncpy(simiStr, aLine + head, simiLength - 1);
				simiStr[simiLength - 1] = '\0';

				TotalSimilarity[i][j] = atof(simiStr);
				head += simiLength;
			}
		}
		fclose(fin);
	}
	else
	{
		MsgError(pchDataFile);
	}

	int i = 0;
	for (i = 0; i <= TOTAL_PHENOTYPES - 1; i++)
	{
		Phenotype* pI = NULL;
		pI = (Phenotype*) bsearch(&TotalPhenotypes[i], PhenotypeIDIndex, iMaxPhenotype, sizeof(Phenotype), PhenotypeCompare);

		int j = 0;
		for (j = 0; j <= TOTAL_PHENOTYPES - 1 && j <= i; j++)
		{
			Phenotype* pJ = NULL;
			pJ = (Phenotype*) bsearch(&TotalPhenotypes[j], PhenotypeIDIndex, iMaxPhenotype, sizeof(Phenotype), PhenotypeCompare);

			if (pI != NULL && pJ != NULL)
			{
				phenotypesSimilarity[i][j] = TotalSimilarity[pI->iID][pJ->iID];
				phenotypesSimilarity[j][i] = phenotypesSimilarity[i][j];
			}
			else
			{}
		}
	}

	MsgWrite(phenotypeSimilarityFileBin);
	FILE* pFile = fopen(phenotypeSimilarityFileBin, "wb");
	if (pFile)
	{
		fwrite(phenotypesSimilarity, sizeof(float), TOTAL_PHENOTYPES * TOTAL_PHENOTYPES, pFile);
		fflush(pFile);
		fclose(pFile);
	}
	else
	{
		MsgError(phenotypeSimilarityFileBin);
	}
}

void ReadMorbidMap()
{
	MsgFunction("ReadMorbidMap");

	int i = 0;
	for (i = 0; i<=TOTAL_PHENOTYPES-1; i++)
	{
		int j =0;
		for (j =0; j<=CAUSE_LOCATIONS-1; j++)
		{
			strcpy(TotalMorbidMaps[i][j].chName, "");
		}
	}

	char name[PROTEIN_LENGTH] = {'\0'};
	char location[16] = {'\0'};

	Phenotype tempPhenotype;

	MsgRead(morbidMapFile);
	FILE* fin = fopen(morbidMapFile, "r");
	if (fin)
	{
		int i = 0;
		for (i = 0; i <= iMax -1 && !feof(fin); i++ )
		{
			char aLine[LINE_LENGTH] = {'\0'};
			fgets(aLine, LINE_LENGTH, fin);
			*(aLine+strlen(aLine)-1) = '\0'; //'\n'也读进来了

			char* posP = aLine;
			char* p = ExtractPhenotypeID(aLine);

			while (p!= NULL)
			{
//debug
	//if (strcpy(name,"210210") == 0)
	//{
	//	cout << "210210";
	//}
	//cout << "debug ReadMorbidMap" << name << endl;
				strcpy(name, p);
				strcpy(tempPhenotype.chName, name);

				char* last = strrchr(aLine, '|');
				strcpy(location, last + 1);

				Phenotype* pResult = NULL;
				pResult = (Phenotype*) bsearch(&tempPhenotype, TotalPhenotypes, TOTAL_PHENOTYPES, sizeof(Phenotype), PhenotypeCompare);
				if (pResult != NULL)
				{
					int pos = pResult -> iID;
					int i = 0;
					for (i = 0; i <= CAUSE_LOCATIONS - 1; i++)
					{
						if (strcmp(TotalMorbidMaps[pos][i].chName, "") == 0)
						{
							strcpy(TotalMorbidMaps[pos][i].chName, name);

							StrToLocation(location, &TotalMorbidMaps[pos][i]);
							break;
						}
						else
						{}
					}
				}
				else
				{}
				posP = strstr(aLine, p);
				posP = posP + PHENOTYPE_LENGTH-1;
				if (posP <= aLine + strlen(aLine) )
				{
					p = ExtractPhenotypeID(posP);
				}
				else
				{}
			}
		}
		fclose(fin);
	}
	else
	{
		MsgError(morbidMapFile);
	}

//test
	//ofstream fout("Data\\test\\morbidmap.test", ios::out);
	//if (fout)
	//{
	//	for (pos = 0; pos <= TOTAL_PHENOTYPES - 1; pos++)
	//	{
	//		fout  << TotalMorbidMaps[pos][0].chName << " ";
	//		for (i = 0; i <= CAUSE_LOCATIONS - 1; i++)
	//
	//		{
	//			fout << "[" << BitToLocation(TotalMorbidMaps[pos][i].start) << "," << BitToLocation(TotalMorbidMaps[pos][i].end) << "] ";
	//		}
	//		fout << "\n";

	//		/*fout  << morbidMap[pos].at(0).chName << " ";
	//		for (vector<MorbidMap>::iterator iter = morbidMap[pos].begin() ; iter <= morbidMap[pos].begin()- 1; iter++)
	//		{
	//			fout << "[" + (*iter).start.oriString << "," << (*iter).end.oriString << "] ";
	//		}
	//		fout << "\n";*/
	//	}
	//	fout.flush();
	//	fout.close();
	//}
	//else
	//{}
}

int PhenotypeCompare(const void* pA, const void* pB)
{
	return strcmp ((*(Phenotype*)pA).chName , (*(Phenotype*)pB).chName);
}

void StrToLocation(char* pStr, MorbidMap* pMorbidMap)
{

////debug
//	if (strcmp(pMorbidMap->chName, "272300") == 0)
//	{
//		cout << "debug: StrToLocation" << endl;
//	}
//	//debug
//	if (pStr.find("cen") != string::npos)
//	{
//		cout << "debug: StrToLocation cen"<< endl;
//	}

	char chroStart[100] = {'\0'};
	char chroEnd[100] = {'\0'};

	char bandStart[100] = {'\0'};
	char bandEnd[100] = {'\0'};

	char chro[8] = {'\0'};

	if (strcmp(strncpy(chro, pStr, 4), "Chr.") == 0)
	{
		strcpy(chroStart, pStr+4);
		strcpy(chroEnd, chroStart);
	}
	else
	{
		char* posP = strchr(pStr, 'p');
		char* posQ = strchr(pStr, 'q');
		char* posCen = strstr(pStr, "cen");

		if (posP || posQ || posCen)
		{
			if (posP == NULL)
			{
				posP = pStr + strlen(pStr);
			}
			else
			{}
			if (posQ == NULL)
			{
				posQ = pStr + strlen(pStr);
			}
			else
			{}
			if (posCen == NULL)
			{
				posCen = pStr + strlen(pStr);
			}
			else
			{}

			char* pos = posP;
			if (posQ < pos)
			{
				pos = posQ;
			}
			else {}
			if (posCen < pos)
			{
				pos = posCen;
			}
			else {}

			//string tempChrom = pStr.substr(0, pos);
			char tempChrom[4] = {'\0'};
			strncpy(tempChrom, pStr, pos - pStr);


			//string::size_type posHyphen = pStr.find('-');
			char* posHyphen = strchr(pStr, '-');

			//if (posHyphen != string::npos) //两段
			if (posHyphen)
			{
				strncpy(chroStart, pStr, pos - pStr);
				strncpy(bandStart, pos, posHyphen - pos);

				strcpy(chroEnd, chroStart);
				strcpy(bandEnd, posHyphen + 1);
			}
			else
			{

				strncpy(chroStart, pStr, pos-pStr);
				strcpy(bandStart, pos);

				strcpy(chroEnd, chroStart);
				strcpy(bandEnd, bandStart);
			}
		}
		else
		{
			MsgError("StrToLocation");
		}
	}
	pMorbidMap->start = LocationToBit(chroStart, bandStart);
	pMorbidMap->end = LocationToBit(chroEnd, bandEnd);

	//morbidmap 区间本身颠倒，swap
	if ((pMorbidMap->start) > (pMorbidMap->end))
	{
		unsigned int temp = pMorbidMap->start;
		pMorbidMap->start = pMorbidMap->end;
		pMorbidMap->end = temp;
	}
	else
	{}
}

unsigned int LocationToBit(char* pChro, char* pBand)//处理成位
{
	unsigned int result = 0;

	unsigned int chro = 0;
	unsigned int arm = 0;
	unsigned int subOne = 0;
	unsigned int subTwo = 0;
	unsigned int subThree = 0;
	unsigned int subFour = 0;

//debug
//if (pBand.find("ter") != string::npos)
//{
//	cout << "debug:ter" << endl;
//}

	if (strcmp(pChro, "X") == 0)
	{
		chro = 23;
	}
	else if (strcmp(pChro, "Y")  == 0)
	{
		chro = 24;
	}
	else if (strcmp(pChro, "MT") == 0)
	{
		chro = 25;
	}
	else //直接转
	{
		chro = atoi(pChro);
	}

	char* pArmLast = pBand;

	if (strcmp(pBand, "") == 0)
	{
		arm = 0;
		subOne = 0;
		subTwo = 0;
		subThree = 0;
		subFour = 0;
	}
	else
	{
		if (pBand[0] == 'c')
		{
			pArmLast = pBand + 2;
			arm = 1;
		}
		else if (pBand[0] == 'p')
		{
			pArmLast = pBand;
			arm = 2;
		}
		else if (pBand[0] == 'q')
		{
			pArmLast = pBand;
			arm = 3;
		}

		else
		{
			printf("error: not pq,cen");
		}

		char* pDot = strchr(pBand, '.');
		char* pTer = strstr(pBand, "ter");

		if (pTer != NULL)
		{
			subOne = TER;//2^3-1;
			subTwo = TER;//2^3-1;
			subThree = TER;//2^3-1;
			subFour = TER;//2^3-1;
		}
		else
		{
			char one[2];
			char two[2];
			char three[2];
			char four[16];

			if (pDot != NULL)
			{
				char strLast[4] = {'\0'};
				strcpy(strLast, pDot+1);

				subOne = atoi(strncpy(one, pArmLast + 1, 1));
				subTwo = atoi(strncpy(two, pArmLast + 2, 1));

				int len = strlen(strLast);
				if (len == 2)
				{

					subThree = atoi(strncpy(three, pDot + 1, 1));
					subFour = atoi(strcpy(four, pDot + 2));
				}
				else if(len == 1)
				{
					subThree = atoi(strncpy(three, pDot + 1, 1));
					subFour = 0;
				}
				else if (len >= 3) //蛋白质及个别有3，只取2
				{
					subThree = atoi(strncpy(three, pDot + 1, 1));
					subFour = atoi(strcpy(four, pDot + 2));
				}
				else
				{
					MsgError("strlast error");
				}

			}
			else
			{
				char strLast[4] = {'\0'};
				strcpy(strLast, pArmLast + 1);

				if (strlen(strLast) == 2)
				{
					subOne = atoi(strncpy(one, pArmLast + 1, 1));
					subTwo = atoi(strcpy(two, pArmLast + 2));
				}
				else if (strlen(strLast) == 1)
				{
					subOne = atoi(strncpy(one, pArmLast + 1, 1));
					subTwo = 0;
				}
				else if (strcmp(strLast,"") || strLast[0] == '\0')
				{
					subOne = 0;
					subTwo = 0;
				}
				else
				{
					MsgError("strlast error");
				}
				subThree = 0;
				subFour = 0;
			}
		}
	}

	result = (chro << POS_CHRO) | (arm << POS_ARM) | (subOne << POS_SUBONE) | (subTwo << POS_SUBTWO) | (subThree << POS_SUBTHREE) | subFour;
	return result;
}

char* BitToLocation(unsigned int bit)
{
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

	    if (result[strlen(result) - 1] == '.')
		{
			result[strlen(result) - 1]  = '\0';
		}
		else
		{}
	}
	else
	{}

	return result;
}

