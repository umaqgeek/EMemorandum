import { ref } from "vue";
import axios from "axios";
import { API_URL } from "@/utils/constants";
import { getBearerToken, resetBearerToken } from "@/utils/tokenManagement";

export function useApi(requestConfig) {
    const data = ref(null);
    const error = ref(null);
    const loading = ref(false);

    const fetchData = async () => {
        loading.value = true;
        try {
            const response = await axios({
                ...requestConfig,
                headers: {
                    "Content-Type": "application/json",
                    Authorization: `Bearer ${getBearerToken()}`,
                    ...(requestConfig.headers || {}),
                },
            });
            data.value = response.data;
        } catch (err) {
            error.value = err.message || "An error occurred";
            if (requestConfig.onError) {
                requestConfig.onError(err);
            }
        } finally {
            loading.value = false;
        }
    };

    fetchData();

    return {
        data,
        error,
        loading,
        refetch: fetchData,
    };
}

export function useStaffProfile() {
    return useApi({
        method: "get",
        url: `${API_URL}/auth/staff-profile`,
    });
}

export function useValidateMe() {
    return useApi({
        method: "post",
        url: `${API_URL}/auth/validate-me`,
        onError: () => {
            resetBearerToken();
        },
    });
}

export function useGetAllStaff() {
    return useApi({
        method: "get",
        url: `${API_URL}/staff`,
    });
}

export function useGetAllStaffSimple() {
    return useApi({
        method: "get",
        url: `${API_URL}/staff/less`,
    });
}

export function useGetOneStaff(noStaf) {
    return useApi({
        method: "get",
        url: `${API_URL}/staff/${noStaf}`,
    });
}

export function useGetOneStaffSimple(noStaf) {
    return useApi({
        method: "get",
        url: `${API_URL}/staff/less/${noStaf}`,
    });
}

export function useAssignStaffRoles(
    noStaf,
    roles = [],
    roles_Secretariats = []
) {
    return useApi({
        method: "post",
        url: `${API_URL}/staff/assign-role/${noStaf}`,
        data: JSON.stringify({
            roles,
            roles_Secretariats,
        }),
    });
}

export function useGetAllRoles() {
    return useApi({
        method: "get",
        url: `${API_URL}/roles`,
    });
}

export function useGetAllMOU(query = "") {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/all` + (query !== "" ? `?q=${query}` : ""),
    });
}

export function useGetMyMOU(query) {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/mine` + (query !== "" ? `?q=${query}` : ""),
    });
}

export function useGetMOUSelectData() {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/select-data`,
    });
}

export function useMouGenerateNoMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/mou/generate-no`,
        data: JSON.stringify(payload),
    });
}

export function useHandleFileUpload(formData) {
    return useApi({
        method: "post",
        url: `${API_URL}/upload/file`,
        data: formData,
        headers: {
            "Content-Type": "multipart/form-data",
        },
    });
}

export function useMouStoreMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/mou`,
        data: JSON.stringify(payload),
    });
}

export function useGetOneMOU(noMemo = "-") {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/get/${noMemo}`,
    });
}

export function useGetOneMOUKPI(kpiId = "-") {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/kpi/${kpiId}`,
    });
}

export function useMouCommentMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/mou/comment`,
        data: JSON.stringify(payload),
    });
}

export function useMouEvidenceMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/mou/kpi-progress`,
        data: JSON.stringify(payload),
    });
}

export function useMouApprovalRejectionMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/mou/approval`,
        data: JSON.stringify(payload),
    });
}

export function useMouUpdateMemo(payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/mou`,
        data: JSON.stringify(payload),
    });
}

export function useReportByCategory() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-category`,
    });
}

export function useReportByCountry() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-country`,
    });
}

export function useReportByCountryMap() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-country-map`,
    });
}

export function useReportByStatus() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-status`,
    });
}

export function useReportByDue1Year() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-due-a-year`,
    });
}

export function useReportByPTJ() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/by-ptj`,
    });
}

export function useReportDashboardCounts() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/dashboard`,
    });
}

export function useReportDetails() {
    return useApi({
        method: "get",
        url: `${API_URL}/report/details`,
    });
}

export function useFetchMOUFields(params = {}) {
    return useApi({
        method: "get",
        url: `${API_URL}/MOUField`,
        params,
    });
}

export function useCreateMOUField(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/MOUField`,
        data: payload,
    });
}

export function useUpdateMOUField(kodField, payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/MOUField/${kodField}`,
        data: payload,
    });
}

export function useDeleteMOUField(kodField) {
    return useApi({
        method: "delete",
        url: `${API_URL}/MOUField/${kodField}`,
    });
}

export function useFetchMOUIndustryCats(params = {}) {
    return useApi({
        method: "get",
        url: `${API_URL}/MOUIndustryCat`,
        params,
    });
}

export function useCreateMOUIndustryCat(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/MOUIndustryCat`,
        data: payload,
    });
}

export function useUpdateMOUIndustryCat(id, payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/MOUIndustryCat/${id}`,
        data: payload,
    });
}

export function useDeleteMOUIndustryCat(id) {
    return useApi({
        method: "delete",
        url: `${API_URL}/MOUIndustryCat/${id}`,
    });
}

export function useFetchPUUJenisMemos(params = {}) {
    return useApi({
        method: "get",
        url: `${API_URL}/PUUJenisMemo`,
        params,
    });
}

export function useCreatePUUJenisMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/PUUJenisMemo`,
        data: payload,
    });
}

export function useUpdatePUUJenisMemo(id, payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/PUUJenisMemo/${id}`,
        data: payload,
    });
}

export function useDeletePUUJenisMemo(id) {
    return useApi({
        method: "delete",
        url: `${API_URL}/PUUJenisMemo/${id}`,
    });
}

export function useFetchPUUKategoriMemos(params = {}) {
    return useApi({
        method: "get",
        url: `${API_URL}/PUUKategoriMemo`,
        params,
    });
}

export function useCreatePUUKategoriMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/PUUKategoriMemo`,
        data: payload,
    });
}

export function useUpdatePUUKategoriMemo(id, payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/PUUKategoriMemo/${id}`,
        data: payload,
    });
}

export function useDeletePUUKategoriMemo(id) {
    return useApi({
        method: "delete",
        url: `${API_URL}/PUUKategoriMemo/${id}`,
    });
}

export function useFetchPUUScopeMemos(params = {}) {
    return useApi({
        method: "get",
        url: `${API_URL}/PUUScopeMemo`,
        params,
    });
}

export function useCreatePUUScopeMemo(payload) {
    return useApi({
        method: "post",
        url: `${API_URL}/PUUScopeMemo`,
        data: payload,
    });
}

export function useUpdatePUUScopeMemo(id, payload) {
    return useApi({
        method: "put",
        url: `${API_URL}/PUUScopeMemo/${id}`,
        data: payload,
    });
}

export function useDeletePUUScopeMemo(id) {
    return useApi({
        method: "delete",
        url: `${API_URL}/PUUScopeMemo/${id}`,
    });
}
