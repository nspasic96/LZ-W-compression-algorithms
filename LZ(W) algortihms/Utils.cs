﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZ_W__algortihms
{
    public class Utils
    {
        public static readonly int rowsInTLP = 5;
        public static readonly int columnsInTLP = 2;
        public static readonly int rowsUpAndDownInLZ78Table = 5;

        public static Color c1 = Color.Red;
        public static Color c2 = Color.Yellow;
        public static Color c3 = Color.Blue;

        public static void splitTlp(TableLayoutPanel tlp, int n, int m, bool scrolable = false)
        {
            tlp.Controls.Clear();

            tlp.Padding = new System.Windows.Forms.Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0);
            tlp.AutoScroll = false;
            tlp.AutoScroll = true;

            tlp.ColumnCount = m;
            tlp.RowCount = n;

            tlp.ColumnStyles.Clear();
            tlp.RowStyles.Clear();

            for (int i = 0; i < m; i++)
            {
                tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100 / m));
            }

            for (int j = 0; j < n; j++)
            {
                if (!scrolable)
                    tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100 / n));
                else
                    tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30));
            }
        }
        public enum AlgorithmName { LZ77, LZ78, LZW }
        public enum ParameterType { Text, List }
        public struct AlgorithmParameter
        {
            string paramName;
            string currValue;
            ParameterType pt;
            List<string> values;


            public AlgorithmParameter(string name, string defaultVal, ParameterType pt = ParameterType.Text, List<string> values = null)
            {
                paramName = name;
                currValue = defaultVal;
                this.pt = pt;
                this.values = values;
            }

            public string ParamName { get => paramName; set => paramName = value; }
            public string CurrValue { get => currValue; set => currValue = value; }
            public ParameterType PT { get => pt; set => pt = value; }
            public List<string> Values { get => values; set => values = value; }
        }

        public struct AlgorithmStatistic
        {
            string statisticName;
            string statisticValue;

            public AlgorithmStatistic(string name, string value)
            {
                statisticName = name;
                statisticValue = value;
            }

            public string StatisticName { get => statisticName; set => statisticName = value; }
            public string StatisticValue { get => statisticValue; set => statisticValue = value; }
        }

        public struct LZ78Entry
        {
            private string word; //word that is added to dictionary
            private string output; //output of the step
            private int step; //step number
            private int pos; //start position of the substring matched

            public LZ78Entry(string word, string output, int step, int pos)
            {
                this.word = word;
                this.output = output;
                this.step = step;
                this.pos = pos;
            }

            public string Word { get => word; set => word = value; }
            public string Output { get => output; set => output = value; }
            public int Step { get => step; set => step = value; }
            public int Pos { get => pos; set => pos = value; }
        }
        public struct LZWEntry
        {
            private int dictIdx; //dictionary entry number
            private string current; //longest match
            private string next; //next character
            private string output; //output of the step
            private string addToDict; //dictionary new entry

            public LZWEntry(int dictIdx, string current, string next, string output, string addToDict)
            {
                this.dictIdx = dictIdx;
                this.current = current;
                this.next = next;
                this.output = output;
                this.addToDict = addToDict;
            }

            public int DictIdx { get => dictIdx; }
            public string Current { get => current; }
            public string Next { get => next; }
            public string Output { get => output; }
            public string AddToDict { get => addToDict; }
        }

        public struct LZ77DecodeStepInfo
        {
            bool isMatched;
            string decodedSoFar;
            int matchLen;
            int matchStartPosBack;
            int encodedSelectionLength;
            int curPosition;
            int currentEncodedPos;
            string message;

            public LZ77DecodeStepInfo(bool isMatched, string decodedSoFar, int matchLen, int matchStartPosBack, int encodedSelectionLength, int curPosition, int currentEncodedPos, string message)
            {
                this.isMatched = isMatched;
                this.decodedSoFar = decodedSoFar;
                this.matchLen = matchLen;
                this.matchStartPosBack = matchStartPosBack;
                this.encodedSelectionLength = encodedSelectionLength;
                this.curPosition = curPosition;
                this.currentEncodedPos = currentEncodedPos;
                this.message = message;
            }

            public bool IsMatched { get => isMatched;}
            public string DecodedSoFar { get => decodedSoFar; }
            public int MatchLen { get => matchLen; }
            public int MatchStartPosBack { get => matchStartPosBack; }
            public int EncodedSelectionLength { get => encodedSelectionLength; }
            public int CurPosition { get => curPosition; }
            public int CurrentEncodedPos { get => currentEncodedPos; }
            public string Message { get => message; }
        }
        public struct LZ78DecodeStepInfo
        {
            bool endOfMessage;
            int matchIdx;
            string decodedSoFar;
            int currentEncodedPos;
            string message;

            public LZ78DecodeStepInfo(bool endOfMessage, int matchIdx, string decodedSoFar, int currentEncodedPos, string message)
            {
                this.endOfMessage = endOfMessage;
                this.matchIdx = matchIdx;
                this.decodedSoFar = decodedSoFar;
                this.currentEncodedPos = currentEncodedPos;
                this.message = message;
            }

            public bool EndOfMessage { get => endOfMessage; }
            public int MatchIdx { get => matchIdx; }
            public string DecodedSoFar { get => decodedSoFar; }
            public int CurrentEncodedPos { get => currentEncodedPos; }
            public string Message { get => message; set => message = value; }
        }
        public struct LZWDecodeEntry
        {
            private int dictIdx; //dictionary entry number
            private string start; //longest match
            private string next; //next character
            private string whole; //whole word to store in dictionary

            public LZWDecodeEntry(int dictIdx, string start, string next, string whole)
            {
                this.dictIdx = dictIdx;
                this.start = start;
                this.next = next;
                this.whole = whole;
            }

            public int DictIdx { get => dictIdx; set => dictIdx = value; }
            public string Start { get => start; set => start = value; }
            public string Next { get => next; set => next = value; }
            public string Whole { get => whole; set => whole = value; }
        }


        public struct LZWDecodeStepInfo
        {
            bool isReset;
            int relativeDecodeStepIdx;
            int decodedSoFarSelectionLength;
            string decodedSoFar;
            List<LZWDecodeEntry> entries;
            int lastReset;
            int offset;
            bool refined;
            string message;

            public LZWDecodeStepInfo(bool isReset, int lastReset, int offset, int relativeDecodeStepIdx, string decodedSoFar, int decodedSoFarSelectionLength, string message, List<LZWDecodeEntry> entries = null)
            {
                this.isReset = isReset;
                this.lastReset = lastReset;
                this.offset = offset;
                this.relativeDecodeStepIdx = relativeDecodeStepIdx;
                this.decodedSoFar = decodedSoFar;
                this.decodedSoFarSelectionLength = decodedSoFarSelectionLength;
                this.entries = null;
                this.message = message;
                if (entries != null)
                {
                    this.entries = entries.ConvertAll(ent => new LZWDecodeEntry(ent.DictIdx, ent.Start, ent.Next, ent.Whole));
                }
                refined = false;
            }
            public string DecodedSoFar { get => decodedSoFar; set => decodedSoFar = value; }
            public int RelativeDecodeStepIdx { get => relativeDecodeStepIdx; }
            public int DecodedSoFarSelectionLength { get => decodedSoFarSelectionLength; set => decodedSoFarSelectionLength = value; }
            public List<LZWDecodeEntry> Entries { get => entries; set => entries = value; }
            public bool IsReset { get => isReset; }
            public int LastReset { get => lastReset; }
            public int Offset { get => offset; }
            public bool Refined { get => refined; set => refined = value; }
            public string Message { get => message; }
        }

        public struct StepInfo
        {
            //common
            private string stepMessage; //description of the step
            private string output; //if it is new best, the match encoding in output
            private int startPos; //start position of match in rest
            private int matchLen; //length of the match

            //for LZ77
            private int posBack; //number of positions to move left with respect to start posisition to reach match start in window
            private bool newBest; //is it new best result

            //for LZ78 and LZW
            private int prefixIdx;
            private bool doAdd;

            public StepInfo(int posBack, int matchLen, int startPos, string stepMessage, bool newBest, string output)
            {
                this.prefixIdx = -1;
                this.doAdd = false;

                this.posBack = posBack;
                this.matchLen = matchLen;
                this.startPos = startPos;
                this.newBest = newBest;
                this.output = output;
                this.stepMessage = stepMessage;
            }
            public StepInfo(int prefixIdx, int matchLen, int startPos, string stepMessage, string output, bool doAdd)
            {
                this.posBack = -1;
                this.newBest = false;

                this.matchLen = matchLen;
                this.doAdd = doAdd;
                this.startPos = startPos;
                this.output = output;
                this.stepMessage = stepMessage;
                this.prefixIdx = prefixIdx;
            }
            public StepInfo(int prefixIdx, int matchLen, int startPos, string stepMessage, bool doAdd)
            {
                this.posBack = -1;
                this.newBest = false;
                this.output = "";

                this.matchLen = matchLen;
                this.startPos = startPos;
                this.stepMessage = stepMessage;
                this.prefixIdx = prefixIdx;
                this.doAdd = doAdd;
            }

            public int PosBack { get => posBack; }
            public int MatchLen { get => matchLen; }
            public bool NewBest { get => newBest; }
            public string Output { get => output; }
            public int StartPos { get => startPos; }
            public string StepMessage { get => stepMessage; }
            public int PrefixIdx { get => prefixIdx; }
            public bool DoAdd { get => doAdd; }
        }
    }
}
