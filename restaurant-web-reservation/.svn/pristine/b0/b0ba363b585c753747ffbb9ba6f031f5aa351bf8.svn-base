#include "PGRelation.h"

PhenotypeProteinPointer pointerPhenotypeProteins[TOTAL_PHENOTYPES];
int TotalPhenotypeProtein[TOTAL_PHENOTYPEPROTEINS];

void ReadPhenotypeProteinRelationFile()
{
	MsgFunction("ReadPhenotypeProteinRelationFile");
	char phenotypes[PHENOTYPE_LENGTH];
	char protein[PROTEIN_LENGTH];
	char proteinTemp[LINE_LENGTH];

	int phenotypeID = 0;
	int proteinID = 0;

	MsgRead(selectedFile);
	FILE* pFile = fopen(selectedFile, "r");
	if (pFile)
	{
		while (!feof(pFile))
		{
//debug
	/*if (strcmp(phenotypes, "202400") == 0)
	{
		cout << phenotypes;
	}*/
			fscanf(pFile, "%s %s", phenotypes, proteinTemp);//可以跳过空行
			phenotypeID = PhenotypeNameToID(phenotypes);

			int i = 0;
			char* pProteinNameHead = proteinTemp;

			int current = 0;
			for (current = 0; current <= strlen(proteinTemp) - 1 ; current += PROTEIN_LENGTH)
			{
				pProteinNameHead = proteinTemp + current;
				strncpy(protein, pProteinNameHead, PROTEIN_LENGTH - 1);
				protein[PROTEIN_LENGTH - 1] = '\0';

				proteinID = ProteinNameToID(protein);

				phenotypeProtein[phenotypeID][i] =  proteinID;
				i++;
			}
			phenotypeProtein[phenotypeID][i] = CAUSE_PROTEIN_END;
		}
		fclose(pFile);
	}
	else
	{
		printf("File %s open error\n", selectedFile);
	}


//test
	//ofstream fout("Data\\test\\selected.test", ios::out);
	//for (i = 0; i <= TOTAL_PHENOTYPES -1 ; i++)
	//{
	//	for (j = 0; j <= TOTAL_PROTEINS - 1; j++)
	//	{
	//		fout << phenotypeProtein[i][j] << ",";
	//		if (phenotypeProtein[i][j] == CAUSE_PROTEIN_END)
	//		{
	//			break;
	//		}
	//	}
	//	fout<<endl;
	//}
	//fout.flush();
	//fout.close();
}
void CreatePhenotypeProteinRelationFile()
{
	int tCount = 0;
	int i = 0;
	for (i = 0; i <= TOTAL_PHENOTYPES - 1; ++i)
	{
		int rowCount = 0;

		pointerPhenotypeProteins[i].start = tCount;
		int j = 0;
		for (j = 0; j <= CAUSE_PROTEINS - 1 && phenotypeProtein[i][j] != CAUSE_PROTEIN_END; j++)
		{
			TotalPhenotypeProtein[tCount] = phenotypeProtein[i][j];

			rowCount++;
			tCount++;
		}
		pointerPhenotypeProteins[i].offset = rowCount;
	}
	//cout << "total cause protein: " << tCount << endl;
	printf("->TOTAL_PHENOTYPEPROTEINS:%d\n", tCount);

	MsgWrite(pointerPhenotypeProteinFileBin);
	FILE* pFileOut = fopen(pointerPhenotypeProteinFileBin , "wb");
	if (pFileOut)
	{
		fwrite(pointerPhenotypeProteins, sizeof(PhenotypeProteinPointer), TOTAL_PHENOTYPES, pFileOut);
		fflush(pFileOut);
		fclose(pFileOut);
	}
	else
	{
		MsgError(pointerPhenotypeProteinFileBin);
	}

	MsgWrite(phenotypeProteinFileBin);
	if (pFileOut)
	{
		pFileOut = fopen(phenotypeProteinFileBin, "wb");
		fwrite(TotalPhenotypeProtein, sizeof(int), TOTAL_PHENOTYPEPROTEINS, pFileOut);
		fflush(pFileOut);
		fclose(pFileOut);
	}
	else
	{
		MsgError(phenotypeProteinFileBin);
	}
}
