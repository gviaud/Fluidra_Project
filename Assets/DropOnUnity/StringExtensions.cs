using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleObjExtensions
{
    public static class StringExtensions
    {
        public static int IndexOfEndOfLine(this string str, int startAt) {
            int i = str.IndexOf('\n', startAt);
            if(i >= startAt) {
                if(i>0 && str[i-1]=='\r') return i-1;                
                return i;
            }
            return str.IndexOf('\r', startAt);
        }
        public static int IndexOfChars(this string str, string searchChars, int startAt) {
            for(int i=startAt;i<str.Length;i++) {
                char c = str[i];
                if(searchChars.IndexOf(c) >= 0) return i;
            }
            return -1;
        }
        public static int EndOfCharRepetition(this string str, int startAt) {
            if(startAt<str.Length) {
                int i = startAt;
                char c = str[i];
                while(i<str.Length-1) {
                    i++;
                    if(str[i]!=c) return i;
                }
            }
            return str.Length;
        }
        public static string TrimChars(this string str, string trimChars) {
            int b = 0;
            int e = str.Length;
            for(;b<e;b++) {
                char c = str[b];
                if(trimChars.IndexOf(c) < 0) break;
            }

            for(;e>b;e--) {
                char c = str[e];
                if(trimChars.IndexOf(c) < 0) break;
            }
            if(b>0 || e<str.Length) return str.Substring(b,e-b);
            return str;
        }

        public static int MakeInt(this string str) {
            int parsedInt = 0;
            if(str!=null && int.TryParse(str, out parsedInt)) return parsedInt;
            else return 0;
        }
        public static float MakeFloat(this string aStr) {
            float parsedFloat = 0.0f;
            if (aStr!=null && float.TryParse(aStr, out parsedFloat)) return parsedFloat;
            else return 0.0f;
        }
        public static string Truncate(this string str, int maxLength) {
            if(str.Length>maxLength) return str.Substring(0,maxLength);
            return str;
        }

        public static List<int> ToIntList(this string str, char separator) {
            List<int> ints = new List<int>();
            int begin=0;
            bool digitPassed=false;
            str = str + separator;
            for(int i=0;i<str.Length;i++) {
                char c = str[i];
                if(c==separator || i==str.Length-1) {
                    if(begin<i && digitPassed) {
                        int parsedInt = 0;
                        if(int.TryParse(str.Substring(begin, i-begin), out parsedInt)) {
                            ints.Add(parsedInt);
                        }
                        digitPassed=false;
                    }
                    begin=i;
                }
                if((int)c>47 && (int)c<58) digitPassed=true;
                if(!digitPassed) begin=i;  // this skips all \t\r\n shit
            }
            return ints;
        }
        public static float[] ToFloatArray(this string str, char separator) {
            List<float> floats = new List<float>();
            IntoFloatList(str, ref floats, separator);
            return floats.ToArray();
        }
        public static List<float> ToFloatList(this string str, char separator) {
            List<float> floats = new List<float>();
            IntoFloatList(str, ref floats, separator);
            return floats;
        }
        public static void IntoFloatList(this string str, ref List<float> floats, char separator) {
            int begin=0;
            bool digitPassed=false;
            str = str + separator;
            for(int i=0;i<str.Length;i++) {
                char c = str[i];
                if(c==separator || c=='\n' || c=='\r' || i==str.Length-1) {
                    if(begin<i && digitPassed) {
                        float parsedFloat = 0.0f;
                        if(float.TryParse(str.Substring(begin, i-begin), out parsedFloat)) {
                            floats.Add(parsedFloat);
                        }
                        digitPassed=false;
                    }
                    begin=i;
                }
                if((int)c>47 && (int)c<58) digitPassed=true;
                if(!digitPassed) begin=i;  // this skips all \t\r\n shit
            }
        }

        public static List<Vector2> ToVector2List(this string str, char separator) {
            List<Vector2> vectors = new List<Vector2>();
            IntoVector2List(str, ref vectors, separator, 2);
            return vectors;
        }
        public static List<Vector2> ToVector2List(this string str, char separator, int floatsPerValue) {
            List<Vector2> vectors = new List<Vector2>();
            IntoVector2List(str, ref vectors, separator, floatsPerValue);
            return vectors;
        }
        public static void IntoVector2List(this string str, ref List<Vector2> vectors, char separator, int floatsPerValue) {
            int vectorIdx=0;
            Vector2 vector = new Vector2(0,0);
            int begin=0;
            bool digitPassed=false;
            str = str + separator;
            for(int i=0;i<str.Length;i++) {
                char c = str[i];
                if(c==separator || c=='\n' || c=='\r' || i==str.Length-1) {
                    if(begin<i && digitPassed) {
                        float parsedFloat = 0.0f;
                        if(float.TryParse(str.Substring(begin, i-begin), out parsedFloat)) {
                            if(vectorIdx<2) vector[vectorIdx] = parsedFloat;
                            vectorIdx++;
                            if(vectorIdx == floatsPerValue) {
                                vectorIdx = 0;
                                vectors.Add(vector);
                                vector = new Vector2(0,0);
                            }
                        }
                        digitPassed=false;
                    }
                    begin=i;
                }
                if((int)c>47 && (int)c<58) digitPassed=true;
                if(!digitPassed) begin=i;  // this skips all \t\r\n shit
            }
        }

        public static Vector3 ToVector3(this string str, char separator, Vector3 defaultValue) {
            List<Vector3> vectors = new List<Vector3>();
            IntoVector3List(str, ref vectors, separator);
            if(vectors.Count>0) return vectors[0];
            return defaultValue;
        }
        public static List<Vector3> ToVector3List(this string str, char separator) {
            List<Vector3> vectors = new List<Vector3>();
            IntoVector3List(str, ref vectors, separator);
            return vectors;
        }
        public static void IntoVector3List(this string str, ref List<Vector3> vectors, char separator) {
            int vectorIdx=0;
            Vector3 vector = new Vector3(0,0,0);
            int begin=0;
            bool digitPassed=false;
            str = str + separator;
            for(int i=0;i<str.Length;i++) {
                char c = str[i];
                if(c==separator || c=='\n' || c=='\r' || i==str.Length-1) {
                    if(begin<i && digitPassed) {
                        float parsedFloat = 0.0f;
                        if(float.TryParse(str.Substring(begin, i-begin), out parsedFloat)) {
                            vector[vectorIdx++] = parsedFloat;
                            if(vectorIdx == 3) {
                                vectorIdx = 0;
                                vectors.Add(vector);
                                vector = new Vector3(0,0,0);
                            }
                        }
                        digitPassed=false;
                    }
                    begin=i;
                }
                if((int)c>47 && (int)c<58) digitPassed=true;
                if(!digitPassed) begin=i;  // this skips all \t\r\n shit
            }
        }


    }
}