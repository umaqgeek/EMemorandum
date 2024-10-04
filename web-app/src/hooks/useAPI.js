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

export function useGetOneStaff(noStaf) {
    return useApi({
        method: "get",
        url: `${API_URL}/staff/${noStaf}`,
    });
}

export function useAssignStaffRoles(noStaf, roles = []) {
    return useApi({
        method: "post",
        url: `${API_URL}/staff/assign-role/${noStaf}`,
        data: JSON.stringify({
            roles,
        }),
    });
}

export function useGetAllMOU() {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/all`,
    });
}

export function useGetMyMOU() {
    return useApi({
        method: "get",
        url: `${API_URL}/mou/mine`,
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
