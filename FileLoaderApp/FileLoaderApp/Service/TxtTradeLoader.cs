﻿using FileLoaderApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoaderApp.Service
{
    public class TxtTradeLoader : ITradeLoader
    {
        public List<TradeDataItem> LoadData(string filePath)
        {
            List<TradeDataItem> tradeDataItems = new List<TradeDataItem>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                // İlk satırı başlık olarak kabul edelim
                for (int i = 1; i < lines.Length; i++)
                {
                    string[] fields = lines[i].Split(';');

                    if (fields.Length == 6)
                    {
                        TradeDataItem tradeData = new TradeDataItem
                        {
                            Date = DateTime.Parse(fields[0].Trim()),
                            Open = decimal.Parse(fields[1].Trim()),
                            High = decimal.Parse(fields[2].Trim()),
                            Low = decimal.Parse(fields[3].Trim()),
                            Close = decimal.Parse(fields[4].Trim()),
                            Volume = long.Parse(fields[5].Trim())
                        };

                        tradeDataItems.Add(tradeData);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new IOException("Xeta", ex);
            }

            return tradeDataItems;
        }
    }
}