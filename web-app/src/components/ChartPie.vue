<template>
    <div id="chart">
        <apexchart
            type="pie"
            width="380"
            :options="chartOptions"
            :series="series"
        ></apexchart>
    </div>
</template>

<script>
export default {
    name: "ChartPieComponent",
    props: {
        series: Array,
        labels: Array,
    },
    data(props) {
        return {
            chartOptions: {
                chart: {
                    width: 380,
                    type: "pie",
                },
                labels: props.labels,
                responsive: [
                    {
                        breakpoint: 480,
                        options: {
                            chart: {
                                width: 200,
                            },
                            legend: {
                                position: "bottom",
                            },
                        },
                    },
                ],
            },
        };
    },
};
</script>
