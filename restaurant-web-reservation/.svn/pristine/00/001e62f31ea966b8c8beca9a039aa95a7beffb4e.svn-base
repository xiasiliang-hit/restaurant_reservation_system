#include "Statistics.h"

static int metric = EUCLIDEAN;

static float START = 0.0f;  //阈值起点
static int STEP = 1;  //阈值样本数
float POS = 0.0f;

static char pchOrderBaseStr[128] = "Data\\result\\order";
static char pchDistributionBaseStr[128] = "Data\\result\\distribution";

char pchOrderStr[128] = "";
char pchDistributionStr[128] = "";

char pchPerformanceStr[128] = "Data\\result\\performance.txt";
char pchPrecisionStr[128] = "Data\\result\\precision.txt";


//char pchPerformance[128] = "Data\\result\\Performance";

int IntCompare(const void* pA, const void* pB)
{
	return *(int*)pA - *(int*)pB;
}

int FloatCompare(const void* pA, const void* pB)
{
	if(*(const float*)pA < *(const float*)pB)
        return -1;
    return *(const float*)pA > *(const float*)pB;
}
int SimiInteractionCompare(const void* pA, const void* pB)
{
    return ((SimiInteraction*)pA)->simi- ((SimiInteraction*)pB)->simi;
}


//全局取阈值
//static float simi[TOTAL_PHENOTYPES*TOTAL_PHENOTYPES] = {0};
//float getThreshold()
//{
//    //取阈值
//	int k = 0;
//	for (int i = 0; i<= TOTAL_PHENOTYPES-1; i++)
//	{
//		for (int j = 0; j<= TOTAL_PHENOTYPES-1; j++)
//		{
//			simi[k] =phenotypesSimilarity[i][j];
//			k++;
//		}
//	}
//
//	qsort(simi, TOTAL_PHENOTYPES*TOTAL_PHENOTYPES, sizeof(float), FloatCompare);
//	int pos = TOTAL_PHENOTYPES*TOTAL_PHENOTYPES*POS;
//	float threshold = simi[pos];
//	//printf("->Threshold:%f\n", threshold);
//
//	return threshold;
//}

//取阈值,对每个表型取
float getThreshold2(int step_i)
{
    float simi[TOTAL_PHENOTYPES] = {0};
    //取阈值

    for (int j = 0; j<= TOTAL_PHENOTYPES-1; j++)
    {
        simi[j] =phenotypesSimilarity[step_i][j];
    }


	qsort(simi, TOTAL_PHENOTYPES, sizeof(float), FloatCompare);
	int pos = TOTAL_PHENOTYPES*POS;
	float threshold = simi[pos];
//	printf("->Threshold:%f\n", threshold);

	return threshold;
}

//统计
void MakeStatistics()
{
    MsgFunction("MakeStatistics");

//    //取阈值
//    float threshold = 0.0f;
//    threshold = getThreshold();

    //初始化零向量标记数组
	bool zeroVector[TOTAL_PROTEINS];
	memset(zeroVector, true, TOTAL_PROTEINS);

	int realLoss = 0;
	int iCountMatrix = 0;

    //标记全零向量
	for (int j = 0; j <= TOTAL_PROTEINS - 1; j++)
    {
        int iProteinID = TotalProteins[j].iID;
        int iCount = 0;

        for (int k = 0; k <= TOTAL_PHENOTYPES - 1; k++)
        {
            if (interactionMatrix[j][k] > 0.0f)
            {
                iCountMatrix++;
				zeroVector[j] = false;
                break;
            }
            else
            {}
        }
    }
    printf("in interactionMatrix not 0 line:%d\n", iCountMatrix);

	FILE* pFileOrder = fopen(pchOrderStr, "w");
	if(pFileOrder)
	{
		for (int step_i = 0; step_i <= TOTAL_PHENOTYPES - 1; ++step_i)
		{
			bool relate[TOTAL_PROTEINS];  //较相似的表型关联的所有蛋白质的标记
			memset(relate, false, TOTAL_PROTEINS);

//取阈值，对每个表型取
            float threshold = 0.0f;
            threshold = getThreshold2(step_i);

//写错了，全零true的不会增多
//int iCountMatrix = 0;
//for (int j = 0; j <= TOTAL_PROTEINS - 1; j++)
//    {
//        int iProteinID = TotalProteins[j].iID;
//        int iCount = 0;
//
//        for (int k = 0; k <= TOTAL_PHENOTYPES - 1; k++)
//        {
//            if (interactionMatrix[j][k] > 0.0f && phenotypesSimilarity[step_i][k] >= threshold)
//            {
//                iCountMatrix++;
//				zeroVector[j] = false;
//                break;
//            }
//            else
//            {}
//        }
//    }
//printf("in interactionMatrix not 0 line:%d\n", iCountMatrix);

			for (int i = 0; i<= TOTAL_PHENOTYPES-1; i++)
			{
				if (phenotypesSimilarity[step_i][i] >= threshold && step_i != i)//仅取相似度较大的表型，并且排除自身
				{
					for (int k = 0; k <= pointerPhenotypeProteins[i].offset - 1; k++)
					{
						int pos = pointerPhenotypeProteins[i].start + k;

						int proteinID = TotalPhenotypeProtein[pos];
						relate[proteinID] = true;
					}
				}
				else
				{}
			}

			float s_iCount[TOTAL_PROTEINS];
			memset(s_iCount, 0.0f, TOTAL_PROTEINS);

			float s_iCountSort[TOTAL_PROTEINS];
            memset(s_iCount, 0.0f, TOTAL_PROTEINS);

			bool proteinMatch[TOTAL_PROTEINS];  //区间匹配的蛋白质标记
			memset(proteinMatch, false, TOTAL_PROTEINS);

			int iPhenotypeID = TotalPhenotypes[step_i].iID;

			int countNoMatch = 0;
			int countMatch = 0;
			int countLocationCadi = 0;  //区间匹配的蛋白质数量

			for (int step_j = 0; step_j <= TOTAL_PROTEINS - 1; ++step_j)
			{
				int iProteinID = TotalProteins[step_j].iID;
				ProteinLoc p = TotalProteinLocs[iProteinID];

				for (int k = 0; k <= pointerMorbidLocs[step_i].offset - 1 ; k++)
				{
					int pos = pointerMorbidLocs[step_i].start + k;
					MorbidLoc m = TotalMorbidLocs[pos];

					if (isLocationMatch2(m, p) == true)
					{
						countLocationCadi++;
						proteinMatch[step_j] = true;

						break;
					}
					else
					{}
				}

				if (proteinMatch[step_j] == false)
				{
					countNoMatch++;
					continue;
				}
				else if (proteinMatch[step_j] == true ) // && relate[step_j] == true // 零向量参不参与排序&& zeroVector[step_j] == false
				{
					countMatch++;

                    switch (metric)
                    {
                        case EUCLIDEAN:
                        {
                            float iCount = 0;

                            for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
                            {
                                if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
                                {
                                    float x1 = interactionMatrix[iProteinID][iIndex];
                                    float x2 = phenotypesSimilarity[iPhenotypeID][iIndex];
                                    iCount += (x1-x2)*(x1-x2);
                                }
                            }
                            s_iCount[step_j] = iCount;
                            break;
                        }

                        case COSINE:
                        {
                            float mult = 0;
                            float s1 = 0;
                            float s2 = 0;
                            for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
                            {
                                if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
                                {
                                    float x1 = interactionMatrix[iProteinID][iIndex];
                                    float x2 = phenotypesSimilarity[iPhenotypeID][iIndex];

                                    mult+=x1*x2;
                                    s1+= x1*x1;
                                    s2+= x2*x2;
                                }
                            }
                            if (s1*s2 == 0)
                            {
                                s_iCount[step_j] = - 0;
                            }
                            else
                            {
                                s_iCount[step_j] = 0 - mult*mult/(s1*s2);
                            }
                            break;
                        }

                        case PEARSON:
                        {
                            int n = 0;
                            float A = 0.0f, X= 0.0f, Y= 0.0f, X2= 0.0f, Y2 = 0.0f;

                            for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
                            {
                                if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
                                {
                                    float x = interactionMatrix[iProteinID][iIndex];
                                    float y = phenotypesSimilarity[iPhenotypeID][iIndex];

                                    n++;

                                    A += x*y;
                                    X += x;
                                    Y += y;

                                    X2 += x*x;
                                    Y2 += Y*Y;
                                }
                            }
                           // printf("%f\n", (n*A - X*Y));
                           // printf("%f\n", sqrt((float)n*X2 - X*X));
                           // printf("%f\n", sqrt(n*Y2 - Y*Y));

                            if (sqrt((float)n*X2 - X*X)*sqrt(n*Y2 - Y*Y) == 0.0f)
                            {
                                s_iCount[step_j] = - 0;
                            }
                            else
                            {
                                s_iCount[step_j] = 0 -(n*A - X*Y)/(sqrt((float)n*X2 - X*X)*sqrt((float)n*Y2 - Y*Y));
                            }
                            break;
                        }

                        case EUCLIDEAN_POWER:
                        {
                            float iCount = 0;
                            int size = TOTAL_PHENOTYPES - TOTAL_PHENOTYPES*POS; //
                            SimiInteraction array[size];

//                            for (int i = 0; i<=size-1; i++)
//                            {
//                                array[i].simi = 0.0f;
//                                array[i].interaction = 0.0f;
//                            }
                            memset(array, 0, size*sizeof(SimiInteraction));

                            int j = 0;
                            for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
                            {
                                if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
                                {
                                    float x = interactionMatrix[iProteinID][iIndex];
                                    float y = phenotypesSimilarity[iPhenotypeID][iIndex];

                                    array[j].simi = y;
                                    array[j].interaction = x;
                                    j++;
                                }
                            }

                            qsort(array, size, sizeof(SimiInteraction), SimiInteractionCompare);
                            for (int i = 0; i <= size - 1; ++i)
                            {
                                float x = array[i].simi;
                                float y = array[i].interaction;

                                iCount += (x-y)*(x-y)/sqrt(size - i);
                            }

                            s_iCount[step_j] = iCount;

                            break;
                        }

                        case EUCLIDEAN_POWER_POS:
                        {
                            float iCount = 0;
                            int size = TOTAL_PHENOTYPES - TOTAL_PHENOTYPES*POS;
                            SimiInteraction array[size];
                            SimiInteraction array_s[size];

//                            for (int i = 0; i<=size-1; i++)
//                            {
//                                array[i].simi = 0.0f;
//                                array[i].interaction = 0.0f;
//                            }
                            memset(array, 0, size*sizeof(SimiInteraction));

                            int j = 0;
                            for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
                            {
                                if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
                                {
                                    float x = interactionMatrix[iProteinID][iIndex];
                                    float y = phenotypesSimilarity[iPhenotypeID][iIndex];

                                    array[j].simi = y;
                                    array[j].interaction = x;
                                    j++;
                                }
                            }

                            memcpy(array_s, array, size*sizeof(SimiInteraction));
                            qsort(array_s, size, sizeof(SimiInteraction), SimiInteractionCompare);
                            for (int i = 0; i <= size - 1; ++i)
                            {
//                                SimiInteraction iTemp;

//                                iTemp.simi = array[i].simi;
                                //float y = array[i].
                                SimiInteraction* pResult = (SimiInteraction*)bsearch(&array[i], array_s, size, sizeof(float), SimiInteractionCompare);

                                if (pResult != NULL)
                                {
                                    int pos = pResult - array_s;

                                    float x = array[i].simi;
                                    float y = array[i].interaction;

                                    iCount += (x-y)*(x-y)/abs(pos-i);
                                }
                                else
                                {
                                    MsgError("pResult NULL");
                                }
                            }

                            s_iCount[step_j] = iCount;

                            break;
                        }
                        default:
                            MsgError("metric error");
                    }
				}
				else
				{}
			}

			int k = 0;
			for (int j = 0; j <= TOTAL_PROTEINS - 1; ++j)
			{
				if (proteinMatch[j] == true )// && relate[j] == true && zeroVector[j] == false
				{
					s_iCountSort[k] = s_iCount[j];
					k++;
				}
			}

			qsort(s_iCountSort, countMatch, sizeof(float), FloatCompare);

			int realCount = 0;
			int inCount = 0;

			for (int k = 0; k <= pointerPhenotypeProteins[step_i].offset - 1; k++)
			{
				int pos = pointerPhenotypeProteins[step_i].start + k;
				int proteinID = TotalPhenotypeProtein[pos];

				if (zeroVector[proteinID] == false)
				{
					realCount++;
				}
			}

			int fraction = 0;
			float ratio = 1;

			for (k = 0; k <= pointerPhenotypeProteins[step_i].offset - 1; k++)
			{
				int pos = pointerPhenotypeProteins[step_i].start + k;

				int proteinID = TotalPhenotypeProtein[pos];

				/*if (zeroVector[proteinID] == true)
				{
					fprintf(pFileIndex, "%d\n", step_i);
					fprintf(pFileOrder, "#\n");
					fprintf(pFileResult, "#,");
					fprintf(pFileCandidate, "%d\n", countMatch);
				}*/
				/*else if (zeroVector[proteinID] == false && relate[proteinID]==false)
				{
					fprintf(pFileIndex, "%d\n", step_i);
					fprintf(pFileOrder, "L\n");
					fprintf(pFileResult, "L,");
					fprintf(pFileCandidate, "%d\n", countMatch);
				}*/
				//else
					if ( zeroVector[proteinID] == false && proteinMatch[proteinID] == true )//&& relate[proteinID] == true
				{
					float iTmp = s_iCount[proteinID];
					float* pResult = NULL;

					pResult = (float*)bsearch(&iTmp, s_iCountSort, countMatch, sizeof(float), FloatCompare);
					if (pResult != NULL)
					{
						int iOrder = pResult - s_iCountSort;

						fprintf(pFileOrder, "%d %d\n", iOrder, countLocationCadi);

						if (iOrder + 1 <= pointerPhenotypeProteins[step_i].offset)
						{
							fraction++;

							ratio*=(float)fraction/(float)(iOrder+1);
							inCount++;
						}
						else
						{}

					}
					else
					{
						MsgError("float mark not found");
					}
				}

				/*else if (zeroVector[proteinID] == false && relate[proteinID] == false)
				{
					fprintf(pFileIndex, "%d\n", step_i);
					fprintf(pFileOrder, "#\n");
					fprintf(pFileResult, "#,");
					fprintf(pFileCandidate, "%d\n", countMatch);
				}*/

				else
				{}

			}
		}

		fflush(pFileOrder);
		fclose(pFileOrder);
	}
	else
	{
		MsgError("result file error");
	}
}

void CalculateDistribution()
{
    MsgFunction("CalculateDistribution");

    const int N = 100;
    float loc[N];
    for (int i = 0; i<=N-1; i++)
    {
        loc[i] = 0.01*i;
    }

    float rank = 0.0f;
    float candidate = 0.0f;

    for (int k = 0; k <= STEP - 1; k++)
    {
        float count[N];
        memset(count, 0, N*sizeof(float));
//        for (int j = 0; j <= N - 1; j++)
//        {
//            count[j]=0.0f;
//        }

        char fInStr[128] = "";
        strcpy(fInStr, pchOrderBaseStr);
        getFileName(fInStr, k);

        FILE* pFileOrder = fopen(fInStr, "r");

        while (!feof(pFileOrder))
        {
            fscanf(pFileOrder, "%f %f", &rank, &candidate);
            float a = (float)rank/(float)candidate;

            for (int i = 0; i <= N - 1; i++)
            {
                if (i == N - 1)
                {
                    if (a >= loc[i] && a <= 1)
                    {
                        count[i] += 1;
                        break;
                    }
                    else
                    {}
                }
                else
                {
                    if (a >= loc[i] && a < loc[i+1])
                    {
                        count[i] += 1;
                        break;
                    }
                    else
                    {}
                }
            }
        }

        char fOutStr[128] = "";
        strcpy(fOutStr, pchDistributionBaseStr);
        getFileName(fOutStr, k);
        FILE* pFileOut = fopen(fOutStr, "w");

        if (pFileOut )
        {
            for (int i = 0; i <= N-1; i++)
            {
                fprintf(pFileOut, "%f\n", count[i]);
            }
        }
        else
        {}

        fflush(pFileOut);
        fclose(pFileOut);

        fclose(pFileOrder);
    }
}

void CalculatePerformance()
{
    MsgFunction("CalculatePerformance");
    FILE* pFileOrder = NULL;
    FILE* pFilePerformance = fopen(pchPerformanceStr, "w");

    int order = 0;
    int nCandidate = 0;

    for (int i = 0; i <= STEP - 1; i++)
    {
        char fOrderStr[128] = "";
        strcpy(fOrderStr, pchOrderBaseStr);
        getFileName(fOrderStr, i);

        pFileOrder = fopen(fOrderStr, "r");
        //pFilePerformance = fopen(pchPerformanceStr, "w");

        int count = 0;
        float total = 0.0f;

        if (pFileOrder && pFilePerformance)
        {

            while (!feof(pFileOrder))
            {
                fscanf(pFileOrder, "%d %d", &order, &nCandidate);

                float ratio = (float)(order+1)/(float)nCandidate;
                total += 1.0f/ratio;

                count++;

                //fprintf(pFilePerformance, "%f\n", ratio);
            }

            fclose(pFileOrder);
        }
        else
        {
            MsgError("file error");
        }

        float avg = total/count/2;
        fprintf(pFilePerformance, "%f\n", avg);
    }

    fflush(pFilePerformance);
    fclose(pFilePerformance);
}

void CalculatePrecision()
{
    MsgFunction("CalculatePrecision");
    FILE* pFileOrder = NULL;
    FILE* pFilePrecision = fopen(pchPrecisionStr, "w");

    int order = 0;
    int nCandidate = 0;

    for (int i = 0; i <= STEP - 1; i++)
    {
        char fOrderStr[128] = "";
        strcpy(fOrderStr, pchOrderBaseStr);
        getFileName(fOrderStr, i);

        pFileOrder = fopen(fOrderStr, "r");
        //pFilePrecision = fopen(pchPerformanceStr, "w");

        int count = 0;
        //float total = 0.0f;

        if (pFileOrder && pFilePrecision)
        {

            while (!feof(pFileOrder))
            {
                fscanf(pFileOrder, "%d %d", &order, &nCandidate);

                //float ratio = (float)(order+1)/(float)nCandidate;
                //total += 1.0f/ratio;
                if (order == 0)
                {
                    count++;
                }

                //fprintf(pchPrecisionStr, "%f\n", ratio);
            }

            fclose(pFileOrder);
        }
        else
        {
            MsgError("file error");
        }

        //float avg = total/count/2;
        fprintf(pFilePrecision, "%d\n", count);
    }

    fflush(pFilePrecision);
    fclose(pFilePrecision);
}

void Begin()
{
    for (int i = 0; i <= STEP - 1; i++)
    {
        //POS = START + (1-START)/(float)STEP*(float)i;
        printf("Begin:i=%d,POS=%f", i, POS);
        strcpy(pchOrderStr, pchOrderBaseStr);
        getFileName(pchOrderStr, i);

        MakeStatistics();

        if (POS >= 0 && POS < 0.9)
        {
            POS += 0.1;
        }

        else if (POS > 0.9 && POS < 0.99)
        {
            //START = 0.9;
            POS+=0.01;
        }
        else if (POS > 0.99 && POS < 1)
        {
            //START = 0.99;
            POS += 0.001;
        }
        else
        {}
    }
}

void getFileName(char const* const base, int suffix)
{
    char suffixStr[8];
    itoa(suffix, suffixStr, 10);
    strcat(base, suffixStr);
    strcat(base, ".txt");
}



//char pchIndex[128] = "Data\\result\\StatisticsIndex.txt";
//char pchOrder[128] = "Data\\result\\StatisticsOrder";  //记录直接结果 (rank, candidate)
//char pchCandidate[128] = "Data\\result\\StatisticsCandidate.txt";  //
//char pchResult[128] = "Data\\result\\Result.txt";  //另一种评价方式  (Phenotype ID, real genes=r, candidate, (rank), prediction model makes=p, number in=i, i/p, f())
//void MakeStatistics()
//{
//    MsgFunction("MakeStatistics");
//
//    //取阈值
//    float threshold = 0.0f;
//    threshold = getThreshold();
//
//    //初始化零向量标记数组
//	bool zeroVector[TOTAL_PROTEINS];
//	memset(zeroVector, true, TOTAL_PROTEINS);
//
//	int realLoss = 0;
//	int iCountMatrix = 0;
////test
//	/*int iCount = 0;
//	int i = 0;
//	for (i = 0; i <= TOTAL_PROTEINS - 1; i++)
//    {
//        int iProteinID = TotalProteins[i].iID;
//
//        int j = 0;
//        for (j = 0; j <= TOTAL_PROTEINS - 1; j++)
//        {
//            if (proteinSimilarity[i][j] > 0.0f)
//            {
//                iCount++;
//            }
//            else
//            {}
//        }
//    }
//    printf("in ppi not 0:%d\n", iCount);*/
//
//    //标记全零向量
//	for (int k = 0; k <= TOTAL_PROTEINS - 1; k++)
//    {
//        int iProteinID = TotalProteins[k].iID;
//        int iCount = 0;
//
//        for (int j = 0; j <= TOTAL_PHENOTYPES - 1; j++)
//        {
//            if (interactionMatrix[k][j] > 0.0f)
//            {
//                iCountMatrix++;
//				zeroVector[k] = false;
//                break;
//            }
//            else
//            {}
//        }
//    }
//    printf("in interactionMatrix not 0 line:%d\n", iCountMatrix);
//
//	FILE* pFileIndex = fopen(pchIndex, "w");
//	FILE* pFileOrder = fopen(pchOrder, "w");
//	FILE* pFileResult = fopen(pchResult, "w");
//
//	FILE* pFileCandidate = fopen(pchCandidate, "w");
//FILE* pFileReaction = fopen("Data//result//reaction.txt", "w");  //(比值, interaction数量)
//FILE* pFileRealte = fopen("Data//result//relate.txt", "w");  //(比值，表型向量维度)
//
//	if(pFileIndex && pFileOrder && pFileResult)
//	{
//		for (int step_i = 0; step_i <= TOTAL_PHENOTYPES - 1; ++step_i)
//		{
//			bool relate[TOTAL_PROTEINS];  //较相似的表型关联的所有蛋白质的标记
//			memset(relate, false, TOTAL_PROTEINS);
//
//int relateCount = 0;  //相似表型关联的蛋白质总数
//			for (int i = 0; i<= TOTAL_PHENOTYPES-1; i++)
//			{
//				if (phenotypesSimilarity[step_i][i] >= threshold && step_i != i)//仅取相似度较大的表型，并且排除自身
//				{
//					for (int k = 0; k <= pointerPhenotypeProteins[i].offset - 1; k++)
//					{
//						int pos = pointerPhenotypeProteins[i].start + k;
//
//						int proteinID = TotalPhenotypeProtein[pos];
//						relate[proteinID] = true;
//
//						relateCount++;
//					}
//				}
//				else
//				{}
//
//			}
//
////test真关系丢失个数
//			//int c = 0;
//			//for (k = 0; k <= pointerPhenotypeProteins[step_i].offset - 1; k++)
//			//{
//			//	int pos = pointerPhenotypeProteins[step_i].start + k;
//
//			//	int proteinID = TotalPhenotypeProtein[pos];
//			//	if (relate[proteinID] == false)
//			//	{
//			//		c++;
//			//		realLoss++;
//			//		cout<< "lost: " << c <<":"<< realLoss <<endl;
//			//	}
//			//}
//
////printf("%d\n", step_i);
////if (step_i == 2041)
////{
////    printf("");
////}
////if (step_i == 1)
////{
////	cout << "";
////}
//			float s_iCount[TOTAL_PROTEINS];
//			memset(s_iCount, 0.0f, TOTAL_PROTEINS);
//
//			float s_iCountSort[TOTAL_PROTEINS];
//            memset(s_iCount, 0.0f, TOTAL_PROTEINS);
//
//			bool proteinMatch[TOTAL_PROTEINS];  //区间匹配的蛋白质标记
//			memset(proteinMatch, false, TOTAL_PROTEINS);
//
//			int iPhenotypeID = TotalPhenotypes[step_i].iID;
//
//			int countNoMatch = 0;
//			int countMatch = 0;
//			int countLocationCadi = 0;  //  区间匹配的蛋白质数量
//
//			for (int step_j = 0; step_j <= TOTAL_PROTEINS - 1; ++step_j)
//			{
//				int iProteinID = TotalProteins[step_j].iID;
//				ProteinLoc p = TotalProteinLocs[iProteinID];
//
//				for (int k = 0; k <= pointerMorbidLocs[step_i].offset - 1 ; k++)
//				{
//					int pos = pointerMorbidLocs[step_i].start + k;
//					MorbidLoc m = TotalMorbidLocs[pos];
//
//					if (isLocationMatch2(m, p) == true)
//					{
//						countLocationCadi++;
//						proteinMatch[step_j] = true;
//
//						break;
//					}
//					else
//					{}
//				}
//
//				if (proteinMatch[step_j] == false)
//				{
//					countNoMatch++;
//					continue;
//				}
//				else if (proteinMatch[step_j] == true ) // && relate[step_j] == true // 零向量参不参与排序&& zeroVector[step_j] == false
//				{
//					countMatch++;
//
//					float iCount = 0;
//					//float mult = 0;
//					//float s1 = 0;
//					//float s2 = 0;
//					for (int iIndex = 0; iIndex <= TOTAL_PHENOTYPES - 1; ++iIndex)
//					{
//						if (phenotypesSimilarity[iPhenotypeID][iIndex] >= threshold )//~ && iIndex != iPhenotypeID 构造向量时，自身应该排除的
//						{
//							float x1 = interactionMatrix[iProteinID][iIndex];
//							float x2 = phenotypesSimilarity[iPhenotypeID][iIndex];
//							iCount += (x1-x2)*(x1-x2);
//
//							//mult+=x1*x2;
//							//s1+= x1*x1;
//							//s2+= x2*x2;
//						}
//					}
//					s_iCount[step_j] = iCount;
//					//s_iCount[step_j] = mult/(s1*s2);
//				}
//				else
//				{}
////debug
////if (step_i == 1)
////{
////	for (int x = 0; x <= TOTAL_PROTEINS - 1; x++)
////	{
////		cout << s_iCount[step_i][step_j] << endl;
////	}
////}
////s_iCount[step_i][step_j] = (float)iCount/(float)temp[step_j][step_i];
//			}
//
//			int k = 0;
//			for (int j = 0; j <= TOTAL_PROTEINS - 1; ++j)
//			{
//				if (proteinMatch[j] == true )// && relate[j] == true && zeroVector[j] == false
//				{
//					s_iCountSort[k] = s_iCount[j];
//					k++;
//				}
//			}
//
//			qsort(s_iCountSort, countMatch, sizeof(float), FloatCompare);
//
//			fprintf(pFileResult, "%d,%d,%d,(", step_i, pointerPhenotypeProteins[step_i].offset, countLocationCadi);
//
//			int realCount = 0;
//			int inCount = 0;
//
//			for (int k = 0; k <= pointerPhenotypeProteins[step_i].offset - 1; k++)
//			{
//				int pos = pointerPhenotypeProteins[step_i].start + k;
//				int proteinID = TotalPhenotypeProtein[pos];
//
//				if (zeroVector[proteinID] == false)
//				{
//					realCount++;
//				}
//			}
//
//			int fraction = 0;
//			float ratio = 1;
//
//			for (k = 0; k <= pointerPhenotypeProteins[step_i].offset - 1; k++)
//			{
//				int pos = pointerPhenotypeProteins[step_i].start + k;
//
//				int proteinID = TotalPhenotypeProtein[pos];
//
//				/*if (zeroVector[proteinID] == true)
//				{
//					fprintf(pFileIndex, "%d\n", step_i);
//					fprintf(pFileOrder, "#\n");
//					fprintf(pFileResult, "#,");
//					fprintf(pFileCandidate, "%d\n", countMatch);
//				}*/
//				/*else if (zeroVector[proteinID] == false && relate[proteinID]==false)
//				{
//					fprintf(pFileIndex, "%d\n", step_i);
//					fprintf(pFileOrder, "L\n");
//					fprintf(pFileResult, "L,");
//					fprintf(pFileCandidate, "%d\n", countMatch);
//				}*/
//				//else
//					if ( zeroVector[proteinID] == false && proteinMatch[proteinID] == true )//&& relate[proteinID] == true
//				{
//					float iTmp = s_iCount[proteinID];
//					float* pResult = NULL;
////test
////int x = 0;
////for (x = 0; x <= countMatch - 1; x++)
////{
////    if (iTmp == s_iCountSort[x] )
////    {
////        int iOrder = x;
////        fprintf(pFileIndex, "%d\n", step_i);
////        fprintf(pFileOrder, "%d\n", iOrder);
////        fprintf(pFileResult, "%d,", iOrder);
////		fprintf(pFileCandidate, "%d\n", countMatch);
////        break;
////    }
////    else
////    {}
////}
//
////int x = 0;
////for (x = countMatch - 1; x >= 0; x--)
////{
////    if (iTmp == s_iCountSort[x] )
////    {
////        int iOrder = x;
////        fprintf(pFileIndex, "%d\n", step_i);
////        fprintf(pFileOrder, "%d\n", iOrder);
////        fprintf(pFileResult, "%d,", iOrder);
////        break;
////    }
////    else
////    {}
////}
//
//					pResult = (float*)bsearch(&iTmp, s_iCountSort, countMatch, sizeof(float), FloatCompare);
//					if (pResult != NULL)
//					{
//						int iOrder = pResult - s_iCountSort;
//
//						fprintf(pFileIndex, "%d\n", step_i);
//						fprintf(pFileOrder, "%d %d\n", iOrder, countLocationCadi);
//						fprintf(pFileResult, "%d|", iOrder);
//						fprintf(pFileCandidate, "%d\n", countLocationCadi);
//
//
//						if (iOrder + 1 <= pointerPhenotypeProteins[step_i].offset)
//						{
//							fraction++;
//
//							ratio*=(float)fraction/(float)(iOrder+1);
//							inCount++;
//						}
//						else
//						{}
//int reactionCount = 0;
//for (int j = 0; j <= TOTAL_PHENOTYPES - 1; j++)
//{
//    if (interactionMatrix[step_i][j] > 0.0f && phenotypesSimilarity[step_i][j] >= threshold && step_i != j)
//    {
//        reactionCount++;
//    }
//    else
//    {}
//}
//fprintf(pFileReaction,"%f %d\n", (float)iOrder/(float)countLocationCadi, reactionCount);
//fprintf(pFileRealte,"%f %d\n", (float)iOrder/(float)countLocationCadi, relateCount);
//
//
//					}
//					else
//					{
//						MsgError("float mark not found");
//					}
//				}
//
//				/*else if (zeroVector[proteinID] == false && relate[proteinID] == false)
//				{
//					fprintf(pFileIndex, "%d\n", step_i);
//					fprintf(pFileOrder, "#\n");
//					fprintf(pFileResult, "#,");
//					fprintf(pFileCandidate, "%d\n", countMatch);
//				}*/
//
//				else
//				{}
//
//			}
//			if (inCount!=0)
//			{
//			fprintf(pFileResult, "),%d,%d,%f,%f", realCount, inCount, (float)inCount/(float)realCount, ratio);
//			}
//			else
//			{
//			fprintf(pFileResult, "),%d,%d,%f,%f",inCount, realCount, 0.0f,0.0f);
//			}
//			fprintf(pFileResult, "\n");
//		}
//		fflush(pFileIndex);
//		fflush(pFileOrder);
//		fflush(pFileResult);
//
//		fflush(pFileCandidate);
//
//
//		fclose(pFileIndex);
//		fclose(pFileOrder);
//		fclose(pFileResult);
//
//		fclose(pFileCandidate);
//
//
//fflush(pFileReaction);
//fclose(pFileReaction);
//fflush(pFileRealte);
//fclose(pFileRealte);
//	}
//	else
//	{
//		MsgError("result file error");
//	}
//}


