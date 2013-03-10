#include "Test.h"

void LocationAdjust()
{
	MsgFunction("LocationAdjust");

	MorbidMap tempMorbidMaps[CAUSE_LOCATIONS];
	FILE* fout = fopen("Data\\test\\match_adjust_location_bit.test", "w");
	if (fout)
	{
		int excN = 0;

		int reduceCount = 0;
		int addCount = 0;

 		int i = 0;
		for (i = 0; i <= TOTAL_PHENOTYPES - 1; ++i)
		{

			bool exceptionFlag = false;

			fprintf(fout, "%s:", PhenotypeIDToName(i));
			int k = 0;
			for (k = 0; k <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][k].chName, "") != 0; k++)
			{
				MorbidMap m = TotalMorbidMaps[i][k];
				fprintf(fout, "[%s,%s]:", BitToLocation(m.start), BitToLocation(m.end));
			}
//debug
//if (strcmp(TotalMorbidMaps[i][0].chName, "102700") == 0)
//{
//	cout << "debug:102700" << endl;
//}

			int j = 0;
			for (j = 0; j <= CAUSE_PROTEINS - 1 && phenotypeProtein[i][j] != CAUSE_PROTEIN_END; j++)
			{
				int proteinID = phenotypeProtein[i][j];
				ProteinMap* p = &TotalProteinMaps[proteinID];

				bool match= false;

				(*p).match = false;

				int k = 0;
				for (k = 0; k <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][k].chName, "") != 0; k++)
				{
					MorbidMap* m = &TotalMorbidMaps[i][k];

					if (isLocationMatch(*m, *p) == true)
					{
						match = true;

						(*p).match = true;
						(*m).match = true;
						break;
					}
					else
					{//m.match = false;
					}
				}
				if ((*p).match == false)
				{
					exceptionFlag = true;
				}
				else
				{}
			}

			if (exceptionFlag == true)
			{
				excN++;
			}
			else
			{}

			for (j =0; j<=CAUSE_LOCATIONS-1; j++)
            {
                strcpy(tempMorbidMaps[j].chName, "");
                tempMorbidMaps[j].start = 0;
                tempMorbidMaps[j].end = 0;
                tempMorbidMaps[j].match = false;
            }

			//删除没被匹配过的区间
			int newPos = 0;
			int r = 0;
			for (r = 0; r <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][r].chName, "") != 0; r++)
			{
				MorbidMap m = TotalMorbidMaps[i][r];
				//if (m.match == true)
				if (true)
				{
					tempMorbidMaps[newPos] = m;
					newPos++;
				}
				else
				{
					reduceCount++;
				}
			}
			if (newPos <= CAUSE_LOCATIONS - 1)
			{
				strcpy(tempMorbidMaps[newPos].chName, "");
			}
			else
			{}//boundary
			memcpy(TotalMorbidMaps[i], tempMorbidMaps, sizeof(MorbidMap)*CAUSE_LOCATIONS);


			//加入蛋白质有出现过的区间，精度为subTwo
			int noMatchPos = 0;
			for (noMatchPos = 0; noMatchPos <= CAUSE_LOCATIONS - 1 ; noMatchPos++)
			{
				if (strcmp(TotalMorbidMaps[i][noMatchPos].chName, "") ==  0)
				{
					break;
				}
			}

			//首个
			ProteinMap pPre = TotalProteinMaps[phenotypeProtein[i][0]];
			ProteinMap pLast = pPre;
			unsigned int maskToSubTwo = MASK_CHRO | MASK_ARM | MASK_SUBONE | MASK_SUBTWO;
			if (noMatchPos <= CAUSE_LOCATIONS - 1)
			{
				if (pPre.match == false )
				{
					strcpy(TotalMorbidMaps[i][noMatchPos].chName, TotalPhenotypes[i].chName);
					TotalMorbidMaps[i][noMatchPos].start = pPre.pos & maskToSubTwo;
					TotalMorbidMaps[i][noMatchPos].end = pPre.pos & maskToSubTwo;
					TotalMorbidMaps[i][noMatchPos].match = true;

					addCount++;
					noMatchPos++;

					fprintf(fout, "+(%s)," , BitToLocation(pPre.pos)) ;
				}
			}
			else
			{
				printf("error: noMatchPos1");
			}

			//int r = 0;
			for (r = 0; r <= CAUSE_PROTEINS - 1 && phenotypeProtein[i][r] != CAUSE_PROTEIN_END; r++)
			{
				int proteinID = phenotypeProtein[i][r];
				pPre = TotalProteinMaps[proteinID];
				if (noMatchPos <= CAUSE_LOCATIONS - 1)
				{
					if (pPre.match == false  && pPre.pos != pLast.pos) //&& (pPre.pos.oriString[0] != 'H' )
					{
						strcpy(TotalMorbidMaps[i][noMatchPos].chName, TotalPhenotypes[i].chName);
						TotalMorbidMaps[i][noMatchPos].start = pPre.pos & maskToSubTwo;
						TotalMorbidMaps[i][noMatchPos].end = pPre.pos & maskToSubTwo;
						TotalMorbidMaps[i][noMatchPos].match = true;

						addCount++;
						noMatchPos++;
						pLast = pPre;

						fprintf(fout, "+(%s),", BitToLocation(pPre.pos));
					}
					else
					{}
				}
				else
				{
					printf("error: noMatchPos2"); //CAUSE_LOCATIONS 不够
				}
			}
			fprintf(fout, "\n");

			if (noMatchPos <= CAUSE_LOCATIONS - 1)
			{
				strcpy(TotalMorbidMaps[i][noMatchPos+1].chName,"");
			}
			else
			{
				printf("error: noMatchPos3");
			}
		}
		printf("\nno match:%d\n", excN);
		printf("add map:%d\n", addCount);
		printf("reduce map:%d\n", reduceCount);

		fflush(fout);
		fclose(fout);
	}
}
//对原来的map
void LocationMatchTest()
{
	MorbidMap m;
	ProteinMap p;

	MsgFunction("LocationMatchTest");
	FILE* fout = fopen("Data\\test\\match_adjust_bit_1.test", "w");
	if (fout)
	{
		int excN = 0;
		int i = 0;
		for (i = 0; i <= TOTAL_PHENOTYPES - 1; ++i)
		{
//debug
//if (strcmp(TotalMorbidMaps[i][0].chName, "127300") == 0)
//{
//	cout << "debug:127300" << endl;
//}

			bool exceptionFlag = false;

			//printf("%s:", TotalPhenotypes[i].chName);
			int k = 0;
			for (k = 0; k <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][k].chName, "") != 0; k++)
			{
				m = TotalMorbidMaps[i][k];
				fprintf(fout, "%d[%s,%s]:",(int)m.match, BitToLocation(m.start), BitToLocation(m.end));
			}

			int j = 0;
			for (j = 0; j <= CAUSE_PROTEINS - 1 && phenotypeProtein[i][j] != CAUSE_PROTEIN_END; j++)
			{
				int proteinID = phenotypeProtein[i][j];
				p = TotalProteinMaps[proteinID];

				bool match= false;

				int k = 0;
				for (k = 0; k <= CAUSE_LOCATIONS - 1 && strcmp(TotalMorbidMaps[i][k].chName, "") != 0; k++)
				{
					m = TotalMorbidMaps[i][k];

					if (isLocationMatch(m, p) == true)
					{
						fprintf(fout, "1,");
						match = true;
						break;
					}
					else
					{}
				}

				if (match == false)
				{
					fprintf(fout, "%s[%s],", ProteinIDToName(proteinID), BitToLocation(p.pos));
					exceptionFlag = true;
				}
				else
				{}
			}
			fprintf(fout, "\n");

			if (exceptionFlag == true)
			{
				excN++;
			}
		}
		fprintf(fout, "no match:%d\n", excN);
		printf("no match:%d\n", excN);

		fflush(fout);
		fclose(fout);
	}
	else
	{
		MsgError("LocationMatchTest");
	}

}

