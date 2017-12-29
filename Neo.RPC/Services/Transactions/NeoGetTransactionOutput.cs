﻿using System;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;

namespace Neo.RPC.Services.Transactions
{
    /// <Summary>
    ///     gettxout    
    ///     Returns the corresponding transaction output information (returned change), based on the specified hash and index.
    /// 
    ///     Parameters
    ///     Txid: Transaction ID
    ///     N: The index of the transaction output to be obtained in the transaction (starts from 0)
    /// 
    ///     Returns
    ///     Transaction output information
    /// 
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"gettxout","params":["f4250dab094c38d8265acc15c366dc508d2e14bf5699e12d9df26577ed74d657"],"id":1}'
    /// 
    ///     Result
    ///     {
    ///         "jsonrpc": "2.0",
    ///         "id": 15,
    ///         "result": {
    ///             "N": 0,
    ///             "Asset": "c56f33fc6ecfcd0c225c4ab356fee59390af8560be0e930faebe74a6daff7c9b",
    ///             "Value": "2950",
    ///             "Address": "AHCNSDkh2Xs66SzmyKGdoDKY752uyeXDrt"
    ///         }
    ///     }
    /// </Summary>
    public class NeoGetTransactionOutput : RpcRequestResponseHandler<string> //todo DTO
    {
        public NeoGetTransactionOutput(IClient client) : base(client, ApiMethods.gettxout.ToString())
        {
        }

        public Task<string> SendRequestAsync(string txId, int index = 0, object id = null)
        {
            if (txId == null) throw new ArgumentNullException(nameof(txId));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            return base.SendRequestAsync(id, txId, index);
        }

        public RpcRequest BuildRequest(string txId, int index = 0, object id = null)
        {
            if (txId == null) throw new ArgumentNullException(nameof(txId));
            if (index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            return base.BuildRequest(id, txId, index);
        }
    }
}