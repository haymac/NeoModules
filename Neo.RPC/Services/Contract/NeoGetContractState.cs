﻿using System;
using System.Threading.Tasks;
using Neo.JsonRpc.Client;

namespace Neo.RPC.Services.Contract
{
    /// <Summary>
    ///     getcontractstate    
    ///     Queries contract information, according to the contract script hash.
    /// 
    ///     Parameters
    ///     Script_hash：Contract script hash
    /// 
    ///     Returns
    ///     ContractState object
    /// 
    ///     Example
    ///     Request
    ///     curl -X POST --data '{"jsonrpc":"2.0","method":"getcontractstate","params":["ecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9"],"id":1}'
    /// 
    ///     Result
    ///     {
    ///    "jsonrpc": "2.0",
    ///    "id": 1,
    ///    "result": {
    ///       "version": 0,
    ///        "hash": "0xecc6b20d3ccac1ee9ef109af5a7cdb85706b1df9",
    ///        "script": "011fc56b6c766b00527ac46c766b51527ac4616168164e656f2e52756e74696d652e47657454726967676572009c6c766b52527ac46c766b52c3643e0061146109d7f250400e09410cc8efebfa7675b0a844726168184e656f2e52756e74696d652e436865636b5769746e6573736c766b53527ac46247046168164e656f2e52756e74696d652e47657454726967676572609c6c766b54527ac46c766b54c3641204616c766b00c3066465706c6f79876c766b55527ac46c766b55c364110061653d046c766b53527ac462f2036c766b00c30a6d696e74546f6b656e73876c766b56527ac46c766b56c36411006165f8066c766b53527ac462c4036c766b00c30b746f74616c537570706c79876c766b57527ac46c766b57c364110061651e0b6c766b53527ac46295036c766b00c3046e616d65876c766b58527ac46c766b58c3641100616580036c766b53527ac4626d036c766b00c30673796d626f6c876c766b59527ac46c766b59c364110061656d036c766b53527ac46243036c766b00c308646563696d616c73876c766b5a527ac46c766b5ac364110061654c036c766b53527ac46217036c766b00c3087472616e73666572876c766b5b527ac46c766b5bc3647100616c766b51c3c0539c009c6c766b5f527ac46c766b5fc3640e00006c766b53527ac462d4026c766b51c300c36c766b5c527ac46c766b51c351c36c766b5d527ac46c766b51c352c36c766b5e527ac46c766b5cc36c766b5dc36c766b5ec361527265630a6c766b53527ac4628b026c766b00c30962616c616e63654f66876c766b60527ac46c766b60c3644d00616c766b51c3c0519c009c6c766b0112527ac46c766b0112c3640e00006c766b53527ac46245026c766b51c300c36c766b0111527ac46c766b0111c36165190c6c766b53527ac46222026c766b00c309696e666c6174696f6e876c766b0113527ac46c766b0113c36411006165390c6c766b53527ac462f3016c766b00c30d696e666c6174696f6e52617465876c766b0114527ac46c766b0114c3644d00616c766b51c3c0519c009c6c766b0116527ac46c766b0116c3640e00006c766b53527ac462a7016c766b51c300c36c766b0115527ac46c766b0115c36165740f6c766b53527ac46284016c766b00c312696e666c6174696f6e537461727454696d65876c766b0117527ac46c766b0117c3644d00616c766b51c3c0519c009c6c766b0119527ac46c766b0119c3640e00006c766b53527ac46233016c766b51c300c36c766b0118527ac46c766b0118c36165fd0f6c766b53527ac46210016c766b00c3127175657279496e666c6174696f6e52617465876c766b011a527ac46c766b011ac36411006165740f6c766b53527ac462d8006c766b00c3177175657279496e666c6174696f6e537461727454696d65876c766b011b527ac46c766b011bc36411006165a0106c766b53527ac4629b006c766b00c30d746f74616c53616c65734e656f876c766b011c527ac46c766b011cc36411006165a5006c766b53527ac46268006c766b00c30873616c65734e656f876c766b011d527ac46c766b011dc3641100616595106c766b53527ac4623a006c766b00c305696e6e6572876c766b011e527ac46c766b011ec36411006165b6106c766b53527ac4620f0061006c766b53527ac46203006c766b53c3616c756600c56b0f5265642050756c736520546f6b656e616c756600c56b03525058616c756600c56b58616c756600c56b0600d4be4ae924616c756654c56b61146109d7f250400e09410cc8efebfa7675b0a844726168184e656f2e52756e74696d652e436865636b5769746e657373009c6c766b51527ac46c766b51c3640e00006c766b52527ac46293026168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79617c680f4e656f2e53746f726167652e4765746c766b00527ac46c766b00c3c000a06c766b53527ac46c766b53c3640e00006c766b52527ac46232026168164e656f2e53746f726167652e476574436f6e746578741485104d0b1bc285289b17717a6facaa2cbd1712b3070060b7c6c5fe11615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e7465787414130b891dc5341bcef93c077fc7ec5624ee8776f80700f87f24795120615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578741445bcb590e3e0fb0010d7bfde6f7cd39382fd86e90700c0b6403b6f0c615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79070018ee2b7abf3e615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578740873616c65734e656f060041ad29410b615272680f4e656f2e53746f726167652e50757461001485104d0b1bc285289b17717a6facaa2cbd1712b3070060b7c6c5fe11615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f74696679610014130b891dc5341bcef93c077fc7ec5624ee8776f80700f87f24795120615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f7469667961001445bcb590e3e0fb0010d7bfde6f7cd39382fd86e90700c0b6403b6f0c615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f7469667961516c766b52527ac46203006c766b52c3616c75660114c56b6161682953797374656d2e457865637574696f6e456e67696e652e476574536372697074436f6e7461696e65726c766b00527ac46c766b00c361681d4e656f2e5472616e73616374696f6e2e4765745265666572656e63657300c36c766b51527ac46c766b51c36168154e656f2e4f75747075742e47657441737365744964209b7cffdaa674beae0f930ebe6085af9093e5fe56b34a5c220ccdcf6efc336fc59c009c6c766b5c527ac46c766b5cc3640e00006c766b5d527ac4628e036c766b51c36168184e656f2e4f75747075742e476574536372697074486173686c766b52527ac46c766b00c361681a4e656f2e5472616e73616374696f6e2e4765744f7574707574736c766b53527ac461682d53797374656d2e457865637574696f6e456e67696e652e476574457865637574696e67536372697074486173686c766b54527ac4006c766b55527ac4616c766b53c36c766b5e527ac4006c766b5f527ac46286006c766b5ec36c766b5fc3c36c766b60527ac4616c766b60c36168184e656f2e4f75747075742e476574536372697074486173686c766b54c39c6c766b0111527ac46c766b0111c3642d00616c766b55c36c766b60c36168134e656f2e4f75747075742e47657456616c7565936c766b55527ac461616c766b5fc351936c766b5f527ac46c766b5fc36c766b5ec3c09f6371ff6168184e656f2e426c6f636b636861696e2e4765744865696768746168184e656f2e426c6f636b636861696e2e4765744865616465726168174e656f2e4865616465722e47657454696d657374616d706c766b56527ac46c766b56c3045021da59946c766b57527ac46c766b57c36165b00d6c766b58527ac46c766b58c3009c6c766b0112527ac46c766b0112c3643900616c766b52c36c766b55c3617c06726566756e6453c168124e656f2e52756e74696d652e4e6f7469667961006c766b5d527ac4628e016c766b57c36c766b52c36c766b55c361527265300e6c766b55527ac46c766b55c3009c6c766b0113527ac46c766b0113c3640f0061006c766b5d527ac4624e016c766b55c30400e1f505966c766b58c3956c766b59527ac46168164e656f2e53746f726167652e476574436f6e746578746c766b52c3617c680f4e656f2e53746f726167652e4765746c766b5a527ac46168164e656f2e53746f726167652e476574436f6e746578746c766b52c36c766b59c36c766b5ac393615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79617c680f4e656f2e53746f726167652e4765746c766b5b527ac46168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c796c766b59c36c766b5bc393615272680f4e656f2e53746f726167652e50757461006c766b52c36c766b59c3615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f7469667961516c766b5d527ac46203006c766b5dc3616c756651c56b616168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79617c680f4e656f2e53746f726167652e4765746c766b00527ac46203006c766b00c3616c75665ac56b6c766b00527ac46c766b51527ac46c766b52527ac4616c766b52c300a16c766b55527ac46c766b55c3640e00006c766b56527ac462df016c766b00c36168184e656f2e52756e74696d652e436865636b5769746e657373009c6c766b57527ac46c766b57c3640e00006c766b56527ac462a3016168164e656f2e53746f726167652e476574436f6e746578746c766b00c3617c680f4e656f2e53746f726167652e4765746c766b53527ac46c766b53c36c766b52c39f6c766b58527ac46c766b58c3640e00006c766b56527ac46246016c766b53c36c766b52c39c6c766b59527ac46c766b59c3643b006168164e656f2e53746f726167652e476574436f6e746578746c766b00c3617c68124e656f2e53746f726167652e44656c657465616241006168164e656f2e53746f726167652e476574436f6e746578746c766b00c36c766b53c36c766b52c394615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578746c766b51c3617c680f4e656f2e53746f726167652e4765746c766b54527ac46168164e656f2e53746f726167652e476574436f6e746578746c766b51c36c766b54c36c766b52c393615272680f4e656f2e53746f726167652e507574616c766b00c36c766b51c36c766b52c3615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f7469667961516c766b56527ac46203006c766b56c3616c756652c56b6c766b00527ac4616168164e656f2e53746f726167652e476574436f6e746578746c766b00c3617c680f4e656f2e53746f726167652e4765746c766b51527ac46203006c766b51c3616c75665fc56b616168164e656f2e53746f726167652e476574436f6e746578740d696e666c6174696f6e52617465617c680f4e656f2e53746f726167652e4765746c766b00527ac46c766b00c3009c6c766b59527ac46c766b59c3640e00006c766b5a527ac4623e036168164e656f2e53746f726167652e476574436f6e7465787412696e666c6174696f6e537461727454696d65617c680f4e656f2e53746f726167652e4765746c766b51527ac46c766b51c3009c6c766b5b527ac46c766b5bc3640e00006c766b5a527ac462d7026168184e656f2e426c6f636b636861696e2e4765744865696768746168184e656f2e426c6f636b636861696e2e4765744865616465726168174e656f2e4865616465722e47657454696d657374616d706c766b52527ac46c766b52c36c766b51c3946c766b53527ac46c766b53c3009f6c766b5c527ac46c766b5cc3640e00006c766b5a527ac4624d026168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79617c680f4e656f2e53746f726167652e4765746c766b54527ac46c766b53c3038051019651936c766b55527ac4006c766b56527ac4006c766b57527ac4006c766b5d527ac4625100616c766b54c36c766b00c395060010a5d4e800966c766b56527ac46c766b57c36c766b56c3936c766b57527ac46c766b54c36c766b56c3936c766b54527ac4616c766b5dc351936c766b5d527ac46c766b5dc36c766b55c39f6c766b5e527ac46c766b5ec3639bff6168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c796c766b54c3615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e7465787412696e666c6174696f6e537461727454696d656c766b51c36c766b55c3038051019593615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e74657874149d50ddee02df50e0d48d1dcae2c143523d2280ac617c680f4e656f2e53746f726167652e4765746c766b58527ac46168164e656f2e53746f726167652e476574436f6e74657874149d50ddee02df50e0d48d1dcae2c143523d2280ac6c766b58c36c766b57c393615272680f4e656f2e53746f726167652e5075746100149d50ddee02df50e0d48d1dcae2c143523d2280ac6c766b58c36c766b57c393615272087472616e7366657254c168124e656f2e52756e74696d652e4e6f7469667961516c766b5a527ac46203006c766b5ac3616c756653c56b6c766b00527ac461149d50ddee02df50e0d48d1dcae2c143523d2280ac6168184e656f2e52756e74696d652e436865636b5769746e657373009c6c766b51527ac46c766b51c3640e00006c766b52527ac4624f006168164e656f2e53746f726167652e476574436f6e746578740d696e666c6174696f6e526174656c766b00c3615272680f4e656f2e53746f726167652e50757461516c766b52527ac46203006c766b52c3616c756651c56b616168164e656f2e53746f726167652e476574436f6e746578740d696e666c6174696f6e52617465617c680f4e656f2e53746f726167652e4765746c766b00527ac46203006c766b00c3616c756655c56b6c766b00527ac461149d50ddee02df50e0d48d1dcae2c143523d2280ac6168184e656f2e52756e74696d652e436865636b5769746e657373009c6c766b52527ac46c766b52c3640e00006c766b53527ac462bb006168164e656f2e53746f726167652e476574436f6e7465787412696e666c6174696f6e537461727454696d65617c680f4e656f2e53746f726167652e4765746c766b51527ac46c766b51c3009e6c766b54527ac46c766b54c3640e00006c766b53527ac46254006168164e656f2e53746f726167652e476574436f6e7465787412696e666c6174696f6e537461727454696d656c766b00c3615272680f4e656f2e53746f726167652e50757461516c766b53527ac46203006c766b53c3616c756651c56b616168164e656f2e53746f726167652e476574436f6e7465787412696e666c6174696f6e537461727454696d65617c680f4e656f2e53746f726167652e4765746c766b00527ac46203006c766b00c3616c756651c56b616168164e656f2e53746f726167652e476574436f6e746578740873616c65734e656f617c680f4e656f2e53746f726167652e4765746c766b00527ac46203006c766b00c3616c756659c56b611480a4d929aa03042c4bfb538bcfcfd0bdd62d66ac6168184e656f2e52756e74696d652e436865636b5769746e657373009c6c766b56527ac46c766b56c3640e00006c766b57527ac46250026168164e656f2e53746f726167652e476574436f6e746578740a696e6e65725f666c6167617c680f4e656f2e53746f726167652e4765746c766b00527ac46c766b00c3009e6c766b58527ac46c766b58c3640e00006c766b57527ac462f1016168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c79617c680f4e656f2e53746f726167652e4765746c766b51527ac46c766b51c30164950128966c766b52527ac46168164e656f2e53746f726167652e476574436f6e746578740a696e6e65725f666c61670131615272680f4e656f2e53746f726167652e507574616c766b51c36c766b53527ac46c766b52c35f950164966c766b54527ac46c766b52c355950164966c766b55527ac46168164e656f2e53746f726167652e476574436f6e746578741480a4d929aa03042c4bfb538bcfcfd0bdd62d66ac6c766b53c3615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e7465787414950efd679770e40e89a8e150cd37bf44139e40c46c766b54c3615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e74657874142397d5baa3da107e77236dc42b4e2e30483e0b916c766b55c3615272680f4e656f2e53746f726167652e507574616168164e656f2e53746f726167652e476574436f6e746578740b746f74616c537570706c796c766b51c36c766b53c3936c766b54c3936c766b55c393615272680f4e656f2e53746f726167652e50757461516c766b57527ac46203006c766b57c3616c756657c56b6c766b00527ac4616c766b00c3009f6c766b51527ac46c766b51c3640f0061006c766b52527ac462b7006c766b00c3038051019f6c766b53527ac46c766b53c3641400610500949a441e6c766b52527ac4628d006c766b00c30380f4039f6c766b54527ac46c766b54c3641400610500b08ef01b6c766b52527ac46263006c766b00c303803a099f6c766b55527ac46c766b55c3641400610500cc829c196c766b52527ac46239006c766b00c3030075129f6c766b56527ac46c766b56c3641400610500e87648176c766b52527ac4620f0061006c766b52527ac46203006c766b52c3616c75665fc56b6c766b00527ac46c766b51527ac46c766b52527ac4610a4d494e545f434f554e546c766b51c37e6c766b53527ac46168164e656f2e53746f726167652e476574436f6e746578746c766b53c3617c680f4e656f2e53746f726167652e4765746c766b54527ac46c766b00c302100ea0009c6c766b57527ac46c766b57c364e100616c766b54c300a06c766b58527ac46c766b58c3643900616c766b51c36c766b52c3617c06726566756e6453c168124e656f2e52756e74696d652e4e6f7469667961006c766b59527ac462db026c766b52c30500bbeea000a06c766b5a527ac46c766b5ac3644100616c766b51c36c766b52c30500bbeea00094617c06726566756e6453c168124e656f2e52756e74696d652e4e6f74696679610500bbeea0006a52527ac4616168164e656f2e53746f726167652e476574436f6e746578746c766b53c351615272680f4e656f2e53746f726167652e507574616162de00616c766b54c351a06c766b5b527ac46c766b5bc3643900616c766b51c36c766b52c3617c06726566756e6453c168124e656f2e52756e74696d652e4e6f7469667961006c766b59527ac462fd016c766b52c30500488c7a1fa06c766b5c527ac46c766b5cc3644100616c766b51c36c766b52c30500488c7a1f94617c06726566756e6453c168124e656f2e52756e74696d652e4e6f74696679610500488c7a1f6a52527ac4616168164e656f2e53746f726167652e476574436f6e746578746c766b53c352615272680f4e656f2e53746f726167652e50757461616168164e656f2e53746f726167652e476574436f6e746578740873616c65734e656f617c680f4e656f2e53746f726167652e4765746c766b55527ac40600d4be4ae9246c766b55c3946c766b56527ac40600d4be4ae9246c766b55c3a16c766b5d527ac46c766b5dc3643900616c766b51c36c766b52c3617c06726566756e6453c168124e656f2e52756e74696d652e4e6f7469667961006c766b59527ac462cd006c766b56c36c766b52c3a16c766b5e527ac46c766b5ec3645400616c766b51c36c766b52c36c766b56c394617c06726566756e6453c168124e656f2e52756e74696d652e4e6f74696679616c766b55c36c766b56c3936c766b55527ac46c766b56c36a52527ac461621700616c766b55c36c766b52c3936c766b55527ac4616168164e656f2e53746f726167652e476574436f6e746578740873616c65734e656f6c766b55c3615272680f4e656f2e53746f726167652e507574616c766b52c36c766b59527ac46203006c766b59c3616c7566",
    ///        "parameters": [
    ///            "String",
    ///            "Array"
    ///        ],
    ///        "returntype": "ByteArray",
    ///        "storage": true,
    ///        "name": "RPX Sale",
    ///        "code_version": "1.0",
    ///        "author": "Red Pulse",
    ///        "email": "rpx@red-pulse.com",
    ///        "description": "RPX Sale"
    ///    }
    /// }
    /// </Summary>
    public class NeoGetContractState : RpcRequestResponseHandler<DTOs.ContractState>
    {
        public NeoGetContractState(IClient client) : base(client, ApiMethods.getcontractstate.ToString())
        {
        }

        public Task<DTOs.ContractState> SendRequestAsync(string scriptHash, object id = null)
        {
            if (string.IsNullOrEmpty(scriptHash)) throw new ArgumentNullException(nameof(scriptHash));
            return base.SendRequestAsync(id, scriptHash);
        }

        public RpcRequest BuildRequest(string scriptHash, object id = null)
        {
            if (string.IsNullOrEmpty(scriptHash)) throw new ArgumentNullException(nameof(scriptHash));
            return base.BuildRequest(id, scriptHash);
        }
    }
}